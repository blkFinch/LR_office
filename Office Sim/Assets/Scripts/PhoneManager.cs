using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour {

	public GameObject jillScreen;

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	public void PhoneRing(){
		anim.Play("ring");
	}

	public void PhoneIdle(){
		anim.Play("Idle");
	}

	public void AnswerPhone(){
		anim.Play("answer");
		Invoke("PhoneIdle", 0.7f);
	}
}
