using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{

	public Animator anime;
	private float height = 10;
	private float speed = .5f;

	bool startRising = false;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			
			
			startRising = true;
			Debug.Log ("started rising");
			Debug.Log (transform.position.y);
		}
	}

	void Update ()
	{	

		if (startRising && transform.position.y < height) {
			transform.position += new Vector3 (0, Time.deltaTime * speed, 0);
			
		}
		if (transform.position.y >= height)
			SceneManager.LoadScene ("2D");
	}
}
