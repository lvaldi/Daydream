using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour {

	public float velocity = 2f;

	private Rigidbody2D rigid;
	private Animator animator;
	private bool isWalking;
	private float velx;
	private float vely;


	void Awake() {
		rigid = GetComponent<Rigidbody2D> ();
		animator = GetComponent <Animator> ();
		isWalking = false;
	}

	void Update() {

		float input_x = Input.GetAxisRaw ("Horizontal");
		float input_y = Input.GetAxisRaw ("Vertical");


		isWalking = (Mathf.Abs (input_x) + Mathf.Abs (input_y)) > 0;
		animator.SetBool ("isWalking", isWalking);
		if (isWalking) {
			animator.SetFloat ("x", input_x);
			animator.SetFloat ("y", input_y);

			rigid.velocity = new Vector2 (input_x * velocity, input_y * velocity);
		} else {
			rigid.velocity = new Vector2 (0f, 0f);
		}
	}

	//makes the player move for the post credits scene
	public void FinalScene() {
		/*this.transform.position = new Vector3 (10.5f, 0f, 0f);
		Vector3 initPoint = this.transform.position;
		Vector3 midPoint = new Vector3 (0.3f, 0f, 0f);
		Vector3 laughPoint = new Vector2 (-8f, 0f, 0f);

		//change to walk left animation
		animator.SetBool ("isWalking", isWalking);
		animator.SetFloat ("x", -1);
		animator.SetFloat ("y", 0);

		float startTime = Time.time;

		float distance = Vector3.Distance (initPoint, midPoint);
		float distCovered = (Time.time - )
		float fracJourney = 

		this.transform.position = Vector3.Lerp (initPoint, midPoint);*/
	}

}
