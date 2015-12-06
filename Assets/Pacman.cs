using UnityEngine;
using System.Collections;

public class Pacman : MonoBehaviour {

	public GameObject playerSpawn;

	public int lives;
	public float powerTime;

	private int points;
	private int max_points;
	private bool awesomeMode;
	private float timer;

	// Use this for initialization
	void Start () {
		awesomeMode = false;
		timer = 0;
		points = 0;
		max_points = GameObject.FindGameObjectsWithTag("pellet").Length;
		max_points += GameObject.FindGameObjectsWithTag ("powerPellet").Length;
	}
	
	// Update is called once per frame
	void Update () {
		if (awesomeMode) {
			timer += Time.deltaTime;
			if (timer > powerTime) {
				timer = 0;
				awesomeMode = false;
			}
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("pellet")) {
			other.gameObject.SetActive (false);
			points++;
		} else if (other.gameObject.CompareTag ("powerPellet")) {
			other.gameObject.SetActive (false);
			points++;
			awesomeMode = true;
			timer += Time.deltaTime;
		} else if (other.gameObject.CompareTag ("ghost")) {
			if (!awesomeMode) {
				lives--;
				if (lives <= 0) {
					// GO to game over screen
				} else {
					Vector3 pos = playerSpawn.transform.position;
					gameObject.transform.position = pos;
				}
			}
		}

	}
	
}
