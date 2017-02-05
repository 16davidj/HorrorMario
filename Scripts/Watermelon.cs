﻿using UnityEngine;
using System.Collections;

public class Watermelon : MonoBehaviour {

	//Declaration of Variables
	public Transform myTransform;
	public Rigidbody myBody;
	public float xForce;
	public float jumpForce;
	public float extraGrav;
	public float speedLimit;

	private float accumPos;
	private Transform target;
	private bool onGround = true;
	private AudioClip jump;

	// Use this for initialization
	void Start () {
		myTransform = GetComponent<Transform> ();
		myBody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		//Jump, only if the player is touching ground
		if (Input.GetKeyDown ("up") && (onGround == true)) {
			myBody.AddForce (Vector3.up * jumpForce * Time.deltaTime, ForceMode.VelocityChange);

		} 

//		//Move right
//		if (Input.GetKey ("right") && (onGround == false)) { 
//			if(myBody.velocity.x < speedLimit){
//				myBody.AddForce (Vector3.right * xForce * 0.5f * Time.deltaTime, ForceMode.Acceleration);
//			}
//		}  

		if (Input.GetKey ("right")) {
			if(myBody.velocity.x < speedLimit){
				myBody.AddForce (Vector3.right * xForce * Time.deltaTime, ForceMode.Acceleration);
			}
		}  
	
		//Move left
//		if (Input.GetKey ("left") && (onGround == false)) {
//			if(myBody.velocity.x > -speedLimit){
//				myBody.AddForce (Vector3.left * xForce * 0.5f * Time.deltaTime, ForceMode.Acceleration);
//			}
//		}

		if (Input.GetKey ("left")) { 
			if(myBody.velocity.x > -speedLimit){
				myBody.AddForce (Vector3.left * xForce * Time.deltaTime, ForceMode.Acceleration);
			}
		}  
	}	
	
	//Following OnCollision Method's test if the player is touching ground
	void OnTriggerEnter(Collider other) {
		onGround = true;
		
	}
	
	void OnTriggerStay(Collider other) {
		onGround = true;
	}
	
	void OnTriggerExit(Collider other) {
		onGround = false;
	}

	//FixedUpdate is called per physics update
	void FixedUpdate() {
		myBody.AddForce (Vector3.down * extraGrav * Time.deltaTime, ForceMode.Acceleration);
	}
	
}
