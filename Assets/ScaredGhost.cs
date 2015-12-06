using UnityEngine;
using System.Collections;

public class ScaredGhost : MonoBehaviour {

	public Material scared;
	public Material normal;

	public GameObject part1;
	public GameObject part2;
	public GameObject part3;

	public void Scared() {
		part1.GetComponent<Renderer>().material = scared;
		part2.GetComponent<Renderer>().material = scared;
		part3.GetComponent<Renderer>().material = scared;
	}

	public void notScared() {
		part1.GetComponent<Renderer>().material = normal;
		part2.GetComponent<Renderer>().material = normal;
		part3.GetComponent<Renderer>().material = normal;
	}
}
