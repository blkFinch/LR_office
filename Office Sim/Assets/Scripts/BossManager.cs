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
	AlertMeter meter;
	PlayerController pc;

	public GameObject bossScreen;

	// Use this for initialization
	void Start () {
		pc = FindObjectOfType<PlayerController>();
		meter = FindObjectOfType<AlertMeter>();
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
		meter.ClearMeterSprite();
		sprite.enabled = false;
	}

	public void StartCountdown(){
		StartCoroutine("CountDown");
	}

	public void StopCountdown(){
		cd_text.text = " ";
		StopCoroutine("CountDown");
	}

	void PlayerCaught(){
		bossScreen.SetActive(true);
		pc.PlayerDestroyed();
		Invoke("GameOver", 1);
	}

	void GameOver(){
		bossScreen.SetActive(false);
		meter.ClearMeterSprite();
	}

	IEnumerator CountDown(){
		meter.UnlockMeterSprite();
		for(int i = 0; i < 9; i++){
			meter.SwapSprite(i);
			yield return new WaitForSeconds(0.3f);
		}
		
		PlayerCaught();
	}

}
