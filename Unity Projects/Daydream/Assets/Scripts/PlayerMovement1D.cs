using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1D : MonoBehaviour {

	public float horizontalVelocity = 2f;

	private Rigidbody rigid;

	void Awake() {
		rigid = GetComponent <Rigidbody> ();
	}
	 
	void FixedUpdate() {
		if(Input.GetKey (KeyCode.D)) {
			rigid.velocity = new Vector2(horizontalVelocity, 0f);
		} else if(Input.GetKey (KeyCode.A)) {
			rigid.velocity = new Vector2 (-horizontalVelocity, 0f);
		} 
	}

}
