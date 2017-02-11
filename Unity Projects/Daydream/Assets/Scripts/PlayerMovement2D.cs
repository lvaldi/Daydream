using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour {

	public float velocity = 2f;

	private Rigidbody2D rigid;

	void Start() {
		rigid = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if(Input.GetKey (KeyCode.D)) {
			rigid.velocity = new Vector2 (velocity, 0f);
		} else if(Input.GetKey (KeyCode.A)) {
			rigid.velocity = new Vector2 (-velocity, 0f);
		} else if(Input.GetKey (KeyCode.W)) {
			rigid.velocity = new Vector2 (0, velocity);
		} else if(Input.GetKey(KeyCode.S)) {
			rigid.velocity = new Vector2 (0, -velocity);
		}
	}
}
