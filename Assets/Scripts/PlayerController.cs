using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float speed;
	public float playerSpeed;
	public float xMin;
	public float xMax;

	public Sprite kittyLeft;
	public Sprite kittyRight;
	public Sprite kittyNormal;

	private SpriteRenderer sr;

	void Start() {
		sr = GetComponent<SpriteRenderer> ();

		speed = 30;
		PlayerPrefs.SetFloat("Cloud Speed", speed);
	}
	
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");

		setBodyPosition (moveHorizontal);

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		GetComponent<Rigidbody2D> ().velocity = movement * playerSpeed;

		GetComponent<Rigidbody2D> ().position = new Vector3 (
		Mathf.Clamp (GetComponent<Rigidbody2D> ().position.x, xMin, xMax),
		0.0f,
		0.0f
		);

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
			Vector2 touchPosition = Input.GetTouch (0).position;
			double halfScreenX = Screen.width / 2.0;
			Vector3 movement2;

			//Check if it is left or right?
			if (touchPosition.x < halfScreenX) {
				movement2 = new Vector3 (-1.0f, 0.0f, 0.0f);
				GetComponent<Rigidbody2D> ().velocity = movement2 * playerSpeed;			
				setBodyPosition (-1.0f);
			} else if (touchPosition.x > halfScreenX) {
				movement2 = new Vector3 (1.0f, 0.0f, 0.0f);
				GetComponent<Rigidbody2D> ().velocity = movement2 * playerSpeed;			
				setBodyPosition (1.0f);
			}
		}
	}

	void setBodyPosition(float move)
	{
		if (move > 0) {
			sr.sprite = kittyRight;
		}

		if ( move < 0) { 
			sr.sprite = kittyLeft;
		}

		if (move == 0) {
			//sr.sprite = kittyNormal;
		}
	}
}
