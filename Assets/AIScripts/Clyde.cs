using UnityEngine;
using System.Collections;

// 50/50 to hunt player for X time or go to random dest (currently power pellets)
public class Clyde : MonoBehaviour {
	
	public GameObject[] destinations;
	private int currentDestination;
	
	private NavMeshAgent agent;

	public GameObject targetPlayer;
	public float huntingTime;
	private bool hunting;
	private float huntTimer;
	
	// Use this for initialization
	void OnEnable () {
		agent = GetComponent<NavMeshAgent> ();
		hunting = false;
		huntTimer = 0;
		if (Random.value < 0.5f) {
			currentDestination = Random.Range (0, destinations.Length - 1);
			agent.SetDestination (destinations [currentDestination].transform.position);
		} else {
			hunting = true;
			agent.SetDestination (targetPlayer.transform.position);
			currentDestination = Random.Range (0, destinations.Length - 1);
		}
	}
	
	// Update is called once per frame
	void Update () {

		float distanceFromDestination = Vector3.Distance(transform.position,destinations[currentDestination].transform.position);

		if (huntTimer > huntingTime) {
			hunting = false;
		}

		if (hunting) {
			hunting = true;
			huntTimer += Time.deltaTime;
			agent.SetDestination (targetPlayer.transform.position);
		} else if (distanceFromDestination <= 50) {
			if (Random.value < 0.5f) {
				currentDestination = Random.Range (0, destinations.Length - 1);
				agent.SetDestination (destinations [currentDestination].transform.position);
			} else {
				hunting = true;
				agent.SetDestination (targetPlayer.transform.position);
				currentDestination = Random.Range (0, destinations.Length - 1);
			}
		} else {
			hunting = false;
			agent.SetDestination (destinations [currentDestination].transform.position);
		}
	}
	
}