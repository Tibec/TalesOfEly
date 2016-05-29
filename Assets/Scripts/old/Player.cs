using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {
	public int speed;
	public float inertia;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private float remainingInertia;


	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		inertia = remainingInertia = 3;
		speed = PlayerPrefs.GetInt ("speed");

	}

	void ProcessWalk()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// calcul du déplacement
		Vector2 movement = new Vector2 (moveHorizontal*speed, moveVertical*speed);
		rb.velocity = movement;

		// Gestion du sens du personnage
		if (moveHorizontal < 0)
			sr.flipX = true;
		else if(moveHorizontal > 0)
			sr.flipX = false;


		if (moveHorizontal == 0 && moveVertical == 0) {
			if (remainingInertia > 0) {
				remainingInertia -= 1 / 60;


			}
		}

		if (Input.GetKeyDown ("a")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Scene/Village");
		}

		if (moveHorizontal > 0) {
			PlayerData.Instance.Disp ();
		}

		if (moveHorizontal < 0) {
			//PlayerData.Instance.setBidule ("Voilalaaaaaa");
		}

	}

	void FixedUpdate ()
	{
		ProcessWalk ();
	}
}	