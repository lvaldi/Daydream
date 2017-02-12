using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	public GameObject player;
	public float durationToMid = 3f;
	public float thanksTime = 2f;
	public float durationToLaugh = 2.5f;
	public float pauseBeforeLaugh = 1f;
	public AudioSource laughter;
	public GameObject thanksBox;

	private Transform playerTransform;
	private Animator playerAnimator;
	private float startTime;
	private float distance;
	private float currentTime;
	private Vector2 initPoint;
	private Vector2 midPoint;
	private Vector2 laughPoint;
	private bool hasLaughed = false;

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
		playerAnimator.SetBool ("isWalking", true);
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
		float timeAfterThanks = timeAtMid + thanksTime;
		float timeAtLaugh = timeAfterThanks + durationToLaugh;
		float laughInstant = timeAtLaugh + pauseBeforeLaugh;

		if(timeSoFar < durationToMid) {
			playerAnimator.SetBool ("isWalking", true);
			playerAnimator.SetFloat ("x", -1);
			playerAnimator.SetFloat ("y", 0);
			playerTransform.position = Vector2.Lerp (initPoint, midPoint, timeSoFar / durationToMid);
		} else if(timeSoFar < durationToMid + thanksTime){
			playerAnimator.SetBool ("isWalking", false);
			playerAnimator.SetFloat ("x", 0);
			playerAnimator.SetFloat ("y", -1);
			thanksBox.SetActive (true);
		} else if(timeSoFar < timeAtLaugh) {
			thanksBox.SetActive (false);
			playerAnimator.SetBool ("isWalking", true);
			playerAnimator.SetFloat ("x", -1);
			playerAnimator.SetFloat ("y", 0);
			playerTransform.position = Vector2.Lerp (midPoint, laughPoint, (timeSoFar - timeAfterThanks) / durationToLaugh);
		} else if(timeSoFar < laughInstant) {
			playerAnimator.SetBool ("isWalking", false);
			playerAnimator.SetFloat ("x", 0);
			playerAnimator.SetFloat ("y", -1);
		} else if(!hasLaughed){
			playerAnimator.SetBool ("NegativeMode", true);

			playerTransform.localScale *= 10;
			playerTransform.position = new Vector2 (0, 0);

			laughter.Play ();
			hasLaughed = true;
			
		} else {
			playerAnimator.SetBool ("NegativeMode", true);
		}

		currentTime = Time.time;
	}
}
