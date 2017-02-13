using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{

	public float velocity = 2f;
	public float wait = 15f;


	void Update ()
	{
		wait -= Time.deltaTime;
		transform.position += new Vector3 (0, velocity);
		if (wait <= 0) {
			SceneManager.LoadScene ("Post-CreditsScene");
		}
	}
}
