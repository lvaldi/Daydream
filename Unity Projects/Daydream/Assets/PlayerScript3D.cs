using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript3D : MonoBehaviour {
	
	public float rotateSpeed;
	public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
	private Rigidbody rigid;
	private Vector3 forceVector;
	public float force;

	void Start()
	{
		rigid = GetComponent<Rigidbody>();
	}

    void FixedUpdate() {
		if(Input.GetKey(KeyCode.RightArrow)){
			rigid.AddForce(Vector3.right*force);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			rigid.AddForce(Vector3.left*force);
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			rigid.AddForce(Vector3.forward*force);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			rigid.AddForce(Vector3.back*force);
		}
		
    }

}
