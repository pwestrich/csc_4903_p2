using UnityEngine;
using System.Collections;

// Goes to random dest (corners currently), hunts if near player
public class Inky : MonoBehaviour {
	
	public GameObject[] destinations;
	private int currentDestination;

	private NavMeshAgent agent;

	public float awareDistance;
	public GameObject targetPlayer;
	private bool hunting;
	
	// Use this for initialization
	void OnEnable () {
		agent = GetComponent<NavMeshAgent> ();
		hunting = false;
		currentDestination = Random.Range (0, 3);
		agent.SetDestination (destinations[currentDestination].transform.position);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 distanceFromPlayer = transform.position - targetPlayer.transform.position;
		float distanceFromDestination = Vector3.Distance(transform.position,destinations[currentDestination].transform.position);
		if (distanceFromPlayer.magnitude <= awareDistance) {
			hunting = true;
			agent.SetDestination (targetPlayer.transform.position);
		} else if (distanceFromDestination <= 50) {
			hunting = false;
			currentDestination = Random.Range (0, destinations.Length - 1);
			agent.SetDestination (destinations [currentDestination].transform.position);
		} else if (hunting) {
			hunting = false;
			agent.SetDestination (destinations [currentDestination].transform.position);
		}
	}

}