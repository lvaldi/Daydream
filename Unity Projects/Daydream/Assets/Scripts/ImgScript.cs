using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgScript : MonoBehaviour {

	public GameObject Main;
	public Camera cam;
	private float currentTime, pastTime;

	void Start () {
		pastTime = 2;
		currentTime = 0;
	}
	
	void Update () {
		if(currentTime < pastTime){
			currentTime += Time.deltaTime;
		}else{
			Main.gameObject.SetActive(true);
			cam.gameObject.SetActive(false);
			Destroy(this.gameObject);
		}
	}
}
