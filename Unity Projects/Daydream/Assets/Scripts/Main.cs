using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject mazePrefab;
	private bool active;

	void Start () {
	
		Instantiate(mazePrefab, new Vector3(-13, 0.4f, 12), Quaternion.Euler(0, 90, 0));
		Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
	
	}
	
	void Update () {
		
	}
}
