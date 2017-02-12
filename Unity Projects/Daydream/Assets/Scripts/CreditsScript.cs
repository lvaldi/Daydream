using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour {

	public float velocity = 2f;

	void Update() {
		transform.position += new Vector3 (0, velocity);
	}
}
