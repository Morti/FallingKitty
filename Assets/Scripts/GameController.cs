using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cloud1;
	public GameObject cloud2;
	public GameObject cloud3;
	public GameObject cloud4;
	public Vector3 spawnValues;
	private int cloudnr;

	public float startWait;
	public float waveWait;

	public Text scoreText;
	public Text gameOverText;
	public Text restartText;
	public Text highScore;

	private Vector3 oldPosition;
	private Vector3 position;
	private Vector3 tempPosition;
	private bool positionFound;

	private bool gameOver;
	private bool restart;

	private int score;
	private int highscore;
	private int increase;

	private float speed;

	void Start() {
		gameOver = false;
		restart = false;
		positionFound = false;

		gameOverText.text = "";
		restartText.text = "";
		score = 0;
		increase = 1;
		highscore = PlayerPrefs.GetInt("Player Score");

		StartCoroutine (SpawnClouds ());

		InvokeRepeating ("AddToMoney", 1, 1);
	}

	void Update()
	{
		if (restart) 
		{
			if(Input.GetKeyDown(KeyCode.R) || Input.touchCount > 0)
			{
				PlayerPrefs.SetInt("Player Score", highscore);
				Application.LoadLevel(Application.loadedLevel);
			}
		}

		scoreText.text = "Score: " + score;
		highScore.text = "Highscore: " + highscore;
	}

	IEnumerator SpawnClouds() {
		yield return new WaitForSeconds (startWait);

		while (true) {
			if(score > 5 && score % 10 == 1) {
				speed = PlayerPrefs.GetFloat("Cloud Speed");
				PlayerPrefs.SetFloat("Cloud Speed", speed + 5.0f);

			}

			while(!positionFound)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				if(spawnPosition.x > (oldPosition.x + 60) || spawnPosition.x < (oldPosition.x - 60)) {
					position = spawnPosition;
					positionFound = true;
				}
			}

			//Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			oldPosition = position;
			positionFound = false;

			cloudnr = Random.Range (1, 5);

			if (cloudnr == 1)
				Instantiate (cloud1, position, spawnRotation);
			else if(cloudnr == 2)
				Instantiate (cloud2, position, spawnRotation);
			else if(cloudnr == 3)
				Instantiate (cloud3, position, spawnRotation);
			else 
				Instantiate (cloud4, position, spawnRotation);

			yield return new WaitForSeconds (waveWait);

			if(gameOver)
			{
				restartText.text = "Touch screen to restart!";
				restart = true;
				break;
			}
		}
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
		if (score > highscore) {
			highscore = score;
		}
	}

	public void AddToMoney () {
		if (!gameOver) {
			score = score + increase;
		}
	}
}
