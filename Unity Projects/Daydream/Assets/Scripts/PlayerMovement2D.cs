using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour {

	public float velocity = 2f;

	private enum Direction {
		Front, Back, Left, Right
	};
	private Rigidbody2D rigid;
	private Animator animator;
	private Direction direction;

	void Start() {
		rigid = GetComponent<Rigidbody2D> ();
		animator = GetComponent <Animator> ();
		direction = Direction.Front;
	}

	void Update() {
		//animator.Play ("PlayerFrontWalk");
		if(Input.GetKey (KeyCode.D)) {
			rigid.velocity = new Vector2 (velocity, 0f);
			animator.SetTrigger ("playerMoveRight");
			direction = Direction.Right;
		} else if(Input.GetKey (KeyCode.A)) {
			rigid.velocity = new Vector2 (-velocity, 0f);
			animator.SetTrigger ("playerMoveLeft");
			direction = Direction.Left;
		} else if(Input.GetKey (KeyCode.W)) {
			rigid.velocity = new Vector2 (0f, velocity);
			animator.SetTrigger ("playerMoveBack");
			direction = Direction.Back;
		} else if(Input.GetKey(KeyCode.S)) {
			rigid.velocity = new Vector2 (0f, -velocity);
			animator.SetTrigger ("playerMoveFront");
			direction = Direction.Front;
		} else {
			rigid.velocity = new Vector2 (0f, 0f);
			SetIdleDirection ();
		}
	}

	private void SetIdleDirection() {
		switch(direction) {
		case Direction.Right:
			animator.SetTrigger ("playerTurnRight");
			break;
		case Direction.Left:
			animator.SetTrigger ("playerTurnLeft");
			break;
		case Direction.Back:
			animator.SetTrigger ("playerTurnBack");
			break;
		default:
			animator.SetTrigger ("playerTurnFront");
			break;
		}
	}
}
