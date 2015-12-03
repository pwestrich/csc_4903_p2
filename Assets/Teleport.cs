using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public GameObject teleportTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		Vector3 pos = teleportTarget.transform.position;
		other.gameObject.transform.position = pos;
	}
}
