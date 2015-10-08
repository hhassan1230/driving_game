using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]

public class Collectable : MonoBehaviour {
	private Animator anim;
	private ParticleSystem part;
	private Renderer rend;
	private BoxCollider box;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		part = GetComponentInChildren<ParticleSystem> ();
		rend = gameObject.GetComponent<Renderer> ();
		box = gameObject.GetComponent<BoxCollider> ();
	}

	public void Shoot(){
		part.Emit (30);
		rend.enabled = false;
		box.enabled = false;
	}


		


	void OnTriggerEnter (Collider other){
		anim.SetTrigger ("Hit");
		other.SendMessage ("AddPoint");
	}
	

}
