using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour {

	Animator door_anim;
	SpriteRenderer sprite;


	// Use this for initialization
	void Start () {
		door_anim = GetComponentInChildren<Animator>();
		sprite = GetComponentInChildren<SpriteRenderer>();
	}
	
	public void SummonBoss(){
		door_anim.Play("Open");
		Invoke("RenderBoss", 0.4f );
	}

	public void DeSummonBoss(){
		door_anim.Play("Open");
		Invoke("HideBoss", 0.4f );
	}

	public void RenderBoss(){
		sprite.enabled = true;
	}

	public void HideBoss(){
		sprite.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
