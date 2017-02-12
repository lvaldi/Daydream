using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgScriptV2 : MonoBehaviour {

	public GameObject PMovement;
	public GameObject camMovement;
	private float currentTime, pastTime;

	void Start () {
		pastTime = 2;
		currentTime = 0;
	}
	
	void Update () {
		if(currentTime < pastTime){
			currentTime += Time.deltaTime;
		}else{
			PMovement.GetComponent<PlayerMovement2D>().active = true;
			camMovement.GetComponent<CameraBehaviour1D>().active = true;
			this.gameObject.SetActive(false);
		}
	}
}
