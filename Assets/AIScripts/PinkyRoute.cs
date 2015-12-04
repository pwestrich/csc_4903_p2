using UnityEngine;
using System.Collections;

public class PinkyRoute : MonoBehaviour {


	public GameObject[] destinations;
	private int currentDestination;

	private NavMeshAgent agent;
	private float timer;
	
	// Use this for initialization
	void OnEnable () {
		agent = GetComponent<NavMeshAgent> ();
		currentDestination = 0;
		agent.SetDestination (destinations[currentDestination].transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		var distance = Vector3.Distance(transform.position,destinations[currentDestination].transform.position);
		if (distance <= 50) 
		{
			currentDestination++;
			if(currentDestination > destinations.Length - 1)
			{
				currentDestination = 0;
			}
			agent.SetDestination (destinations[currentDestination].transform.position);
		}
	}

}
