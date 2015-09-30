using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour {

	public float tempVelocitiy;
	public float torque;

	private Rigidbody rb;
	private Vector3 driveForce;

	// Use this for initialization
	void Start () {

		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.UpArrow)) {
			driveForce = Vector3.forward * tempVelocitiy;
			print("I am Driving");
//			rb.AddForce(driveForce);
			rb.AddRelativeForce(driveForce);
		};
		if (Input.GetKey(KeyCode.LeftArrow)) {
			rb.AddTorque(transform.up * torque * -1);
		};
		if (Input.GetKey(KeyCode.RightArrow)) {
			rb.AddTorque(transform.up * torque * +1);
		};

	}
	void onCollisionEnter(Collision hit){
		if (hit.gameObject.tag == "target") {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
