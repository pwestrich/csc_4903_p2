using UnityEngine;
using System.Collections;

// Patrols, hunts if near player 
public class Pinky : MonoBehaviour {


	public GameObject[] destinations;
	private int currentDestination;

	private NavMeshAgent agent;

	public float awareDistance;
	public GameObject targetPlayer;
	private bool hunting;
	
	// Use this for initialization
	void OnEnable () {
		agent = GetComponent<NavMeshAgent> ();
		currentDestination = 0;
		hunting = false;
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
			currentDestination++;
			if (currentDestination > destinations.Length - 1) {
				currentDestination = 0;
			}
			agent.SetDestination (destinations [currentDestination].transform.position);
		} else {
			hunting = false;
			agent.SetDestination (destinations [currentDestination].transform.position);
		}
	}

}
