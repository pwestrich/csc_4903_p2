using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pacman : MonoBehaviour {

	public GameObject playerSpawn;

	public Text livesText;
	public Text pointsText;
	public Text statusText;

	public int lives;
	public float powerTime;

	private int points;
	private int max_points;

	private bool awesomeMode;
	private float timer;

	private bool paused;
	private bool gameOver;

	private ScaredGhost[] ghosts;

	void Start () {
		awesomeMode = false;
		timer = 0;

		points = 0;
		max_points = GameObject.FindGameObjectsWithTag("pellet").Length + 
			GameObject.FindGameObjectsWithTag ("powerPellet").Length;

		ghosts = (ScaredGhost[]) FindObjectsOfType(typeof(ScaredGhost));

		paused = false;
		gameOver = false;

		livesText.text = "Lives : " + lives;
		pointsText.text = "" + points;
	}

	void Update () {
		if (awesomeMode) {
			timer += Time.deltaTime;
			if (timer > powerTime) {
				timer = 0;
				awesomeMode = false;
				for (int i = 0; i < ghosts.Length; i++) {
					ghosts[i].notScared();
				}
			}
		}

		if (Input.GetKeyDown ("escape")) {
			if (paused) {
				Time.timeScale = 0.0f;
				statusText.text = "PAUSED";
			} else {
				Time.timeScale = 1.0f;
				statusText.text = "";
			}
			paused = !paused;
		}

		if (Input.GetKeyDown ("r") && gameOver) {
			gameOver = false;
			Application.LoadLevel(Application.loadedLevel);
			Time.timeScale = 1.0f;
		}

		//if (Input.GetMouseButtonDown ("Fire1") && awesomeMode) {
			// Shooot stuff
			// Gun noises
			// Enemy dead noise
		//}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("pellet")) {
			other.gameObject.SetActive (false);
			points++;
			pointsText.text = "" + points;
			if (points == max_points) {
				Time.timeScale = 0.0f;
				statusText.text = "YOU WIN";
				gameOver = true;
				// Start win music?!
			}
		} else if (other.gameObject.CompareTag ("powerPellet")) {
			other.gameObject.SetActive (false);
			points++;
			for (int i = 0; i < ghosts.Length; i++) {
				ghosts[i].Scared();
			}
			// Start power pellet music?!
			pointsText.text = "" + points;
			awesomeMode = true;
			if (points == max_points) {
				Time.timeScale = 0.0f;
				statusText.text = "YOU WIN";
				// Start win music?!
			}
		} else if (other.gameObject.CompareTag ("ghost")) {
			if (!awesomeMode) {
				lives--;
				if (lives <= 0) {
					Time.timeScale = 0.0f;
					statusText.text = "YOU LOSE";
					gameOver = true;
					// Start defeat music?!
				} else {
					livesText.text = "Lives : " + lives;
					Vector3 pos = playerSpawn.transform.position;
					gameObject.transform.position = pos;
					// Death noise?
				}
			}
		}

	}

	public bool getAwesome() {
		return awesomeMode;
	}
	
}
