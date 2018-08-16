using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGame : MonoBehaviour {

	Animator anim;
	GameManager gm;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		gm = FindObjectOfType<GameManager>();
	}
	
	public void Cover(){
		anim.Play("cover");
		if(gm != null){
			gm.SetScreenIsHidden("true");
		}
	}
	public void UnCover(){
		anim.Play("idle");
		if(gm != null){
			gm.SetScreenIsHidden("false");
		}
	}
}
