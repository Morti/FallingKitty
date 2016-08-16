using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public void runGame() {
		Application.LoadLevel("Main");
	}

	public void endGame() {
		PlayerPrefs.Save();
		Application.Quit();
	}
}
