using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject mazePrefab;

	void Start () {
		
		Instantiate(mazePrefab, new Vector3(-12, 0.4f, 12), Quaternion.Euler(0, 90, 0));
		Instantiate(playerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
	}
	
	void Update () {
		
	}
}
