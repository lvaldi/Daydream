using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImgScriptV3 : MonoBehaviour {

	private float currentTime, pastTime;

	void Start () {
		pastTime = 2;
		currentTime = 0;
	}
	
	void Update () {
		if(currentTime < pastTime){
			currentTime += Time.deltaTime;
		}else{

			SceneManager.LoadScene("1D");
		}
	}
}
