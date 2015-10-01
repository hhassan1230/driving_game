﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class carController : MonoBehaviour {

	public float tempVelocitiy;
	public float torque;
	public bool canDrive;
	public Text countdownTimerText;
	public int countdownDecNum;

	private Rigidbody rb;
	private Vector3 driveForce;

	// Use this for initialization
	void Start () {
		countdownDecNum = 5;
		canDrive = true;

		rb = gameObject.GetComponent<Rigidbody>();
		InvokeRepeating ("timerTick", 1, 1);
		// when it start then when it repeats
		countdownTimerText.text = countdownDecNum.ToString();
	}

	void timerTick(){
		countdownDecNum--;
		countdownTimerText.text = countdownDecNum.ToString();
		if (countdownDecNum <= 0) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (canDrive) {
			if (Input.GetKeyDown (KeyCode.LeftShift))
				tempVelocitiy *= 2;
			if (Input.GetKeyUp (KeyCode.LeftShift))
				tempVelocitiy /= 2;
			
			if (Input.GetKey(KeyCode.UpArrow)) {
				driveForce = Vector3.forward * tempVelocitiy;
				rb.AddRelativeForce(driveForce);
			};
			if (Input.GetKey(KeyCode.DownArrow)) {
				driveForce = Vector3.back * tempVelocitiy;
				rb.AddRelativeForce(driveForce);
			};
			if (Input.GetKey(KeyCode.LeftArrow)) {
				rb.AddTorque(transform.up * torque * -1);
			};
			if (Input.GetKey(KeyCode.RightArrow)) {
				rb.AddTorque(transform.up * torque * +1);
			};
		}

	}

	void OnCollisionEnter(Collision hit){
		if (hit.gameObject.tag == "target") {
			print("I hit the target");
			Application.LoadLevel(Application.loadedLevel +1);
//			Application.LoadLevel("level2");
		}
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "control"){
			canDrive = false;
		}
	}
}
