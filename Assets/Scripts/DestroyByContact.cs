﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	private GameController gameController;


	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Boundary") {
			return;
		}

		if (other.tag == "Player") {
			Destroy (other.gameObject);
			gameController.GameOver();
		}
	}
}
