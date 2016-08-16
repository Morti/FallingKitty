using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateHighScore : MonoBehaviour {
	
	public Text highScore;
	private int highscore;

	void Start () {
		highscore = PlayerPrefs.GetInt("Player Score");
		highScore.text = "Highscore: " + highscore;
	}
}
