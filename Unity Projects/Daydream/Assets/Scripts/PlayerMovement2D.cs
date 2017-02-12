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
		/*
		if(Input.GetKey (KeyCode.D)) {
			rigid.velocity = new Vector2 (velocity, 0f);
		} else if(Input.GetKey (KeyCode.A)) {
			rigid.velocity = new Vector2 (-velocity, 0f);
		} else if(Input.GetKey (KeyCode.W)) {
			rigid.velocity = new Vector2 (0f, velocity);
		} else if(Input.GetKey(KeyCode.S)) {
			rigid.velocity = new Vector2 (0f, -velocity);
		} else {
			rigid.velocity = new Vector2 (0f, 0f);
		} */

		float input_x = Input.GetAxisRaw ("Horizontal");
		float input_y = Input.GetAxisRaw ("Vertical");


		isWalking = (Mathf.Abs (input_x) + Mathf.Abs (input_y)) > 0;
		animator.SetBool ("isWalking", isWalking);
		if (isWalking) {
			Debug.Log ("isWalking is true!!!");
			animator.SetFloat ("x", input_x);
			animator.SetFloat ("y", input_y);

			transform.position += new Vector3 (input_x, input_y).normalized * velocity * Time.deltaTime;
		}
	}

}
