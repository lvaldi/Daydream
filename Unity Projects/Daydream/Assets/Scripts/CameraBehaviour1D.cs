using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour1D : MonoBehaviour {

	public GameObject player;

	private Vector3 distCameraPlayer;

	void Awake() {
		distCameraPlayer = transform.position - player.transform.position;
	}

	void Update() {
		transform.position = player.transform.position + distCameraPlayer;
	}
}
