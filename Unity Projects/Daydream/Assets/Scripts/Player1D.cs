using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1D : MonoBehaviour
{
	int currentLayer = 1;
	float MovementColdDown = 0.1f;
	float currentColdDown = 0f;
	//from 1 to 7
	int xpos = 1;
	//from 0-14, where 0 and 14 are walls, not reachable by player
	Material currentColour;
	public Material[] Colours;
	public Image ZeroD;
	public Image Dot;
	bool goalReached = false;

	//	Renderer dotRend;

	// Use this for initialization
	void Start ()
	{
		currentLayer = 1;
		currentColour = Colours [0];
		gameObject.GetComponent<Renderer> ().material = currentColour;

		;
//		dotRend=Dot.GetComponent<Renderer>();
		Color color = ZeroD.color;
		Color dotColor = Dot.color;
		color.a = 0;
		ZeroD.color = color;
		dotColor.a = 0;
		Dot.color = dotColor;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (xpos == 13 && currentLayer == 7) {
			goalReached = true;
		}
		if (!goalReached) {
			currentColdDown -= Time.deltaTime;
			if (currentColdDown <= 0) {
				move ();
			}
		} else {
			Color color = ZeroD.color;
			color.a += 0.01f;
			ZeroD.color = color;
			if (ZeroD.color.a >= 1) {
				Color dotColor = ZeroD.color;
				dotColor.a += 0.02f;
				Dot.color = dotColor;
				if (Dot.color.a >= 1 && Dot.transform.localScale.x < 20) {
					Dot.transform.localScale =
						new Vector3 (1.1f * Dot.transform.localScale.x, 1.1f * Dot.transform.localScale.y, 1.1f * Dot.transform.localScale.z);
				}
				if (Dot.transform.localScale.x >= 20) {
					SceneManager.LoadScene ("Credits");
				}
			}


		}



	}

	void move ()
	{
		
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			if (!isWall (xpos + 1)) {
				gameObject.transform.position += new Vector3 (1, 0, 0);
				xpos++;
				currentColdDown = MovementColdDown;
			}
		} else if (Input.GetAxisRaw ("Horizontal") < 0) {
			if (!isWall (xpos - 1)) {
				gameObject.transform.position -= new Vector3 (1, 0, 0);
				xpos--;
				currentColdDown = MovementColdDown;
			}
		} else if (Input.GetAxisRaw ("Vertical") > 0) {
			tryNextLayer ();
		} else if (Input.GetAxisRaw ("Vertical") < 0) {
			tryPreviousLayer ();
		}
	}

	bool isWall (int nextPos)
	{
		if (nextPos == 0 || nextPos == 14) {
			return true;
		}
		switch (currentLayer) {
		case 1:
			break; //no wall in first layer
		
		case 2:
			if (nextPos == 4 || nextPos == 10) {
				return true;
			}
			break;

		case 3:
			if (nextPos == 7 || nextPos == 12) {
				return true;
			}
			break;

		case 4:
			if (nextPos == 5 || nextPos == 9) {
				return true;
			}
			break;
		
		case 5:
			if (nextPos == 5) {
				return true;
			}
			break;
		
		case 6:
			if (nextPos == 10) {
				return true;
			}
			break;

		case 7:
			if (nextPos == 8) {
				return true;
			}
			break;
		}
		return false;
	}

	void tryNextLayer ()
	{
		switch (currentLayer) {
		case(1):
			if (xpos == 7 || xpos == 12) {
				NextLayer ();
			}
			break;
		case (2):
			if (xpos == 2 || xpos == 9 || xpos == 13) {
				NextLayer ();
			}
			break;
		case (3):
			if (xpos == 1 || xpos == 6 || xpos == 8 || xpos == 13) {
				NextLayer ();
			}
			break;
		case (4):
			if (xpos == 3) {
				NextLayer ();
			}
			break;
		case (5):
			if (xpos == 2 || xpos == 6 || xpos == 12) {
				NextLayer ();
			}
			break;
		case (6):
			if (xpos == 4 || xpos == 11) {
				NextLayer ();
			}
			break;
		case (7):
			//max, can't go
			break;

		}
	}

	void tryPreviousLayer ()
	{
		switch (currentLayer) {

		case (1):
			//max, can't go
			break;

		case(2):
			if (xpos == 7 || xpos == 12) {
				PrevLayer ();
			}
			break;
		case (3):
			if (xpos == 2 || xpos == 9 || xpos == 13) {
				PrevLayer ();
			}
			break;
		case (4):
			if (xpos == 1 || xpos == 6 || xpos == 8 || xpos == 13) {
				PrevLayer ();
			}
			break;
		case (5):
			if (xpos == 3) {
				PrevLayer ();
			}
			break;
		case (6):
			if (xpos == 2 || xpos == 6 || xpos == 12) {
				PrevLayer ();
			}
			break;
		case (7):
			if (xpos == 4 || xpos == 11) {
				PrevLayer ();
			}
			break;
	

		}
	}

	void NextLayer ()
	{
		currentLayer++;
		currentColour = Colours [currentLayer - 1];
		gameObject.GetComponent<Renderer> ().material = currentColour;
		currentColdDown = MovementColdDown;
	}

	void PrevLayer ()
	{
		currentLayer--;
		currentColour = Colours [currentLayer - 1];
		gameObject.GetComponent<Renderer> ().material = currentColour;
		currentColdDown = MovementColdDown;
	}
}
