using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	public GameObject player;
	public float durationToMid = 3;
	public float durationToLaugh = 2.5f;

	private Transform playerTransform;
	private Animator playerAnimator;
	private float startTime;
	private float distance;
	private float currentTime;
	private Vector2 initPoint;
	private Vector2 midPoint;
	private Vector2 laughPoint;

	void Start() {
		playerTransform = player.GetComponent <Transform>();
		playerAnimator = player.GetComponent <Animator> ();
		playerTransform.position = new Vector2 (10.5f, 0.3f);
		PlayerMovement2D playerScript = player.GetComponent <PlayerMovement2D>();

		this.transform.position = new Vector2 (10.5f, 0f);
		initPoint = this.transform.position;
		midPoint = new Vector2 (0.3f, 0f);
		laughPoint = new Vector2 (-8f, 0f);

		//change to walk left animation
		playerAnimator.SetBool ("isWalking", playerScript.isWalking);
		playerAnimator.SetFloat ("x", -1);
		playerAnimator.SetFloat ("y", 0);

		startTime = Time.time;
		distance = Vector2.Distance (initPoint, midPoint);
		durationToMid = 3.0f;
		currentTime = Time.time;

		playerScript.RemovePlayerControl ();
	}

	void Update() {
		float timeSoFar = currentTime - startTime;
		float timeAtMid = startTime + durationToMid;
		if(timeSoFar < durationToMid) {
			playerTransform.position = Vector2.Lerp (initPoint, midPoint, timeSoFar / durationToMid);
		} else if(timeSoFar < durationToMid + durationToLaugh) {
			playerTransform.position = Vector2.Lerp (midPoint, laughPoint, (timeSoFar - timeAtMid) / durationToLaugh);
		}

		currentTime = Time.time;
	}
}
