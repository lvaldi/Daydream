using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript3D : MonoBehaviour {
	
	private float inputDelay = 0.1f;
	private float forwardVel = 3;
	private float sideVel = 2;
	private float rotateVel = 100;
	Quaternion targetRotation;
	Rigidbody rb;
	float forwardInput, turnInput, sideInput;
	private float xRot, yRot, xSens, ySens;
	public float jumpHeight, jumpPower;
	private bool onGround;

	 
	public Quaternion TargetRotation(){
		return targetRotation;
	}

	void Start(){
		targetRotation = transform.rotation;
		if(GetComponent<Rigidbody>())
			rb = GetComponent<Rigidbody>();

		forwardInput = turnInput = 0;
		xSens = 5;
		ySens = 5;
		onGround = false;
	}

	void GetInput(){
		forwardInput = Input.GetAxis("Vertical");
		sideInput = Input.GetAxis("Horizontal");
	}

	void Update(){
		GetInput();
		Turn();
		
		Debug.Log(onGround);
	}

	void FixedUpdate()
	{
		Run();
		if(Input.GetKey(KeyCode.Space) && onGround) Jump();
	}

	void Run(){

		if (Mathf.Abs(forwardInput) > inputDelay){
			//move
			rb.velocity += transform.forward * forwardInput * forwardVel;
			Debug.Log("forward");
		}
		if(Mathf.Abs(sideInput) > inputDelay){
			rb.velocity += transform.right * sideInput * sideVel;
			Debug.Log("side");
		}
	}
	
	void Turn(){
		xRot += Input.GetAxis("Mouse X") * xSens;
		yRot -= Input.GetAxis("Mouse Y") * ySens;
		if(yRot <= 170) Camera.main.transform.localEulerAngles = new Vector3(yRot, 0, 0);
		transform.localEulerAngles = new Vector3(0, xRot, 0);
	}

	void Jump(){
		rb.velocity += (Vector3.up * jumpPower);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Floor"){
			onGround = true;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if(other.collider.tag == "Floor"){
			onGround = false;
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	/*
	public GameObject cam;
	private Rigidbody rigid;
	private Vector3 moveToVector;
	private float xPos, zPos;
	private const float yPos = 0;
	private float speed;
	private Vector3 moveDirection;
	private float xRot, yRot, xSens, ySens;


	void Awake()
	{	
		DOTween.Init();
		rigid = GetComponent<Rigidbody>();
		speed = 10;
		xSens = 5;
		ySens = 5;
	}

    void Update() {
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) transform.position += transform.right * Time.deltaTime * speed;
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) transform.position -= transform.right * Time.deltaTime * speed;
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) transform.position += transform.forward * Time.deltaTime * speed;
		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) transform.position -= transform.forward * Time.deltaTime * speed;
		moveToVector = new Vector3(xPos, yPos, zPos) + transform.forward * Time.deltaTime;
		
		//transform.DOMove(moveToVector, 1);
		
		
		

		xRot += Input.GetAxis("Mouse X") * xSens;
		yRot -= Input.GetAxis("Mouse Y") * ySens;
		transform.localEulerAngles = new Vector3(yRot, xRot, 0);
		//transform.DORotate(new Vector3(yRot, xRot, 0), 1, RotateMode.Fast);
		transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime, 0);
    }*/
}
