using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour {

	public float speed;
	
	void Start ()
	{
		speed = PlayerPrefs.GetFloat ("Cloud Speed");
		GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,5 * speed);
	}
}
