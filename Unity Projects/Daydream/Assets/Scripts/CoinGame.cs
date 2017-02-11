using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinGame : MonoBehaviour
{
	public Image Coin;
	public Text CoinCount;
	public bool isCoinDragging;
	public Image[] Coins;
	public Image CoinPile;

	// Use this for initialization
	void Start ()
	{
		Coin.enabled = false;
		isCoinDragging = false;
	}

	//	void OnMouseDown ()
	//	{
	//		print ("Hello");
	//
	//	}

	void OnMouseUp ()
	{
		Coin.enabled = false;
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			isCoinDragging = true;
			Coin.enabled = true;
		}

		if (isCoinDragging) {
			Coin.transform.position = Input.mousePosition;
		}

		if (Input.GetMouseButtonUp (0)) {
			isCoinDragging = false;
			Coin.enabled = false;
		}
	}
}
