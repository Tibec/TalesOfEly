using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed;
	public int jumpSquat;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private int jumping;
	private bool jumpReleased;
	private int jumpstarter;
	private bool crouched;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		jumping = 0;
		jumpReleased = true;
		jumpstarter = -1;
		crouched = false;
	}

	void ProcessWalk()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (crouched)
			return;

		// calcul du déplacement
		Vector2 movement = new Vector2 (moveHorizontal*speed, moveVertical*speed);
		rb.velocity = movement;

		// Gestion du sens du personnage
		if (moveHorizontal < 0)
			sr.flipX = true;
		else if(moveHorizontal > 0)
			sr.flipX = false;

	}


	void ProcessJump()
	{
		bool moveVertical = Input.GetKey ("up");

		if (!moveVertical && jumping > 0)
			jumpReleased = true;

		if(rb.velocity.y == 0 && jumping==2)
		{
			jumping = 0;
		}
		else if(rb.velocity.y < 0 && jumping==1)
		{
			jumping = 2;
		}

		if (jumpstarter == 0) {
			jumping = 1;
			GetComponent<Animator> ().enabled = false;
			Object[] sprites = Resources.LoadAll ("mario");
			sr.sprite = (Sprite)sprites [5];
			if(moveVertical)
				rb.AddForce (new Vector2 (0, 90));
			else
				rb.AddForce (new Vector2 (0, 55));
			jumpstarter = -1;
		}
		else if (jumpstarter > 0)
			--jumpstarter;
		

		// Gestion du saut
		if (moveVertical  && jumping==0 && jumpReleased && !crouched) {
			jumpstarter = jumpSquat;
			jumpReleased = false;
		}

	}

	void ProcessCrouch()
	{
		if (Input.GetKey ("down")) {
			crouched = true;
			//GetComponent<BoxCollider2D> ().size = new Vector2 (0.14f, 0.14f);
			//GetComponent<BoxCollider2D> ().offset = new Vector2 (0.0f, -0.07f);
		} else {
			crouched = false;
			//GetComponent<BoxCollider2D> ().size = new Vector2 (0.14f, 0.26f);
			//GetComponent<BoxCollider2D> ().offset = new Vector2 (0.0f, 0.0f);
		}
	}

	void FixedUpdate ()
	{
		ProcessWalk ();
		//ProcessJump ();
		//ProcessCrouch ();


		// Gestion animation
		/*if (crouched) {
			GetComponent<Animator> ().enabled = false;
			Object[] sprites = Resources.LoadAll ("mario");
			sr.sprite = (Sprite)sprites [2];
		} else if (rb.velocity == new Vector2 (0, 0) && jumping == 0) {
			GetComponent<Animator> ().enabled = false;
			Object[] sprites = Resources.LoadAll ("mario");
			sr.sprite = (Sprite)sprites [1];
		} else if(jumping == 0) {
			GetComponent<Animator> ().enabled = true;
		}*/

	}
}	