using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene2to1 : MonoBehaviour {

	public GameObject img;
	private bool canGo;
	void Start(){

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player"){
			Debug.Log("workds");
			img.SetActive(true);

			if(canGo)
				SceneManager.LoadScene("1D");
		}
	}
}
