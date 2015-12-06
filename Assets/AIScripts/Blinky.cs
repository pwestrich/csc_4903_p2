using UnityEngine;
using System.Collections;

// Wanders, hunts player if near
public class Blinky : MonoBehaviour
{
	
	public float awareDistance;
	public float wanderRadius;
	public GameObject targetPlayer;

	private NavMeshAgent agent;
	private Vector3 currentDestination;
	private bool hunting;
	
	// Use this for initialization
	void OnEnable ()
	{
		agent = GetComponent<NavMeshAgent> ();
		hunting = false;
		currentDestination = RandomNavSphere (transform.position, wanderRadius, -1);
		agent.SetDestination (currentDestination);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 distanceFromPlayer = transform.position - targetPlayer.transform.position;
		Vector3 distanceFromDestination = transform.position - currentDestination;
		Vector3 newPos;
		if (distanceFromPlayer.magnitude <= awareDistance) {
			hunting = true;
			newPos = targetPlayer.transform.position;
			agent.SetDestination (newPos);
		} else if (distanceFromDestination.magnitude <= 50 || hunting) {
			hunting = false;
			newPos = RandomNavSphere (transform.position, wanderRadius, -1);
			currentDestination = newPos;
			agent.SetDestination (newPos);
		} else {
			hunting = false;
		}
	}
	
	public static Vector3 RandomNavSphere (Vector3 origin, float dist, int layermask)
	{
		Vector3 randDirection = Random.insideUnitSphere * dist;

		randDirection += origin;
		
		NavMeshHit navHit;
		
		NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
		
		return navHit.position;
	}
}