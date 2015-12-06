using UnityEngine;
using System.Collections;

public class Inky : MonoBehaviour {
	
	public GameObject[] destinations;
	private int currentDestination;
	
	private Transform target;
	private NavMeshAgent agent;
	
	// Use this for initialization
	void OnEnable () {
		agent = GetComponent<NavMeshAgent> ();
		currentDestination = Random.Range (0, 3);
		agent.SetDestination (destinations[currentDestination].transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		var distance = Vector3.Distance(transform.position,destinations[currentDestination].transform.position);
		if (distance <= 50) 
		{
			currentDestination = Random.Range (0, 3);
			agent.SetDestination (destinations[currentDestination].transform.position);
		}
	}

}