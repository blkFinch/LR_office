using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGame : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	public void Cover(){
		anim.Play("cover");
	}
	public void UnCover(){
		anim.Play("idle");
	}
}
