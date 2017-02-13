using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour {

	[HideInInspector]public bool isWalking;
	public float velocity = 2f;

	private Rigidbody2D rigid;
	private Animator animator;
	private float velx;
	private float vely;
	private bool playerHasControl;
	public bool active;


	void Awake() {
		rigid = GetComponent<Rigidbody2D> ();
		animator = GetComponent <Animator> ();
		isWalking = false;
		playerHasControl = true;
	}

	void Update() {
		if(!active) return;

		float input_x = 0.0f;
		float input_y = 0.0f;

		if(playerHasControl){
			input_x = Input.GetAxisRaw ("Horizontal");
			input_y = Input.GetAxisRaw ("Vertical");
		}


		isWalking = (Mathf.Abs (input_x) + Mathf.Abs (input_y)) > 0;
		animator.SetBool ("isWalking", isWalking);
		if (isWalking) {
			if(playerHasControl){
				animator.SetFloat ("x", input_x);
				animator.SetFloat ("y", input_y);
			}

			rigid.velocity = new Vector2 (input_x * velocity, input_y * velocity);
		} else {
			rigid.velocity = new Vector2 (0f, 0f);
		}
	}
	/*
	//makes the player move for the post credits scene
	public void FinalScene() {
		Debug.Log ("Just entered Final Scene function");
		this.transform.position = new Vector2 (10.5f, 0f);
		Vector2 initPoint = this.transform.position;
		Vector2 midPoint = new Vector2 (0.3f, 0f);
		Vector2 laughPoint = new Vector2 (-8f, 0f);

		//change to walk left animation
		animator.SetBool ("isWalking", isWalking);
		animator.SetFloat ("x", -1);
		animator.SetFloat ("y", 0);

		float startTime = Time.time;
		float distance = Vector2.Distance (initPoint, midPoint);
		float durationToMid = 3.0f;
		float currentTime = Time.time;

		while(currentTime - startTime < durationToMid) {
			Debug.Log ("Im in the final scene loop");
			float timeSoFar = currentTime - startTime;
			this.transform.position = Vector2.Lerp (initPoint, midPoint, timeSoFar / durationToMid);
			currentTime = Time.time;
		}
		Debug.Log ("And now im out");
	}
	*/

	public void RemovePlayerControl() {
		playerHasControl = false;
	}
}
