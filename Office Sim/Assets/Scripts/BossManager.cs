using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour {

	Animator door_anim;
	SpriteRenderer sprite;

	public Text cd_text;
	public int countdownTime;

	LevelManager lm;

	// Use this for initialization
	void Start () {
		lm = FindObjectOfType<LevelManager>();
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

	public void StartCountdown(){
		StartCoroutine("CountDown");
	}

	public void StopCountdown(){
		cd_text.text = " ";
		StopCoroutine("CountDown");
	}

	IEnumerator CountDown(){
		int count = countdownTime;
		for(int i = 0; i < countdownTime; i++){
			cd_text.text = count.ToString();
			count--;
			yield return new WaitForSeconds(1);
		}
		lm.LoadGameOver();
	}

}
