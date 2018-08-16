using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// turn true to begin boss loop
	public bool bossInPlay  = false;
	public bool phoneInPlay = false;
	
	BossManager bm;
	public float _bps = 0.2f;

	PhoneManager pm;
	public float _pps = 0.1f;

	bool phoneIsActive = false;
	bool bossIsActive = false;
	bool screenIsHidden = false;
	bool counting = false;

	public GameObject[] formations;
	private GameObject formation;

	int playerLives = 2;
	LifeCounter lc;

	LevelManager lm;
	ScoreManager sm;
	PlayerController pc;

	int score;

	// Use this for initialization
	void Start () {
		lm = FindObjectOfType<LevelManager>();
		bm = FindObjectOfType<BossManager>();
		lc = FindObjectOfType<LifeCounter>();
		pc = FindObjectOfType<PlayerController>();
		sm = FindObjectOfType<ScoreManager>();
		pm = FindObjectOfType<PhoneManager>();

		SpawnFormation();
	}

	public void SetScreenIsHidden(string setting ){
		if(setting == "true"){
			screenIsHidden = true;
		}
		else{ screenIsHidden = false; }
	}

	int PickFormation(){
		return Random.Range(0, formations.Length);
	}

	public void SpawnFormation(){
		int form = PickFormation();
		formation = Instantiate(formations[form], transform.position, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if(!bossIsActive){
			float p = _bps * Time.deltaTime;
	        if(Random.value < p) { ActivateBoss(); }
		}

		if(!phoneIsActive){
			float t = _pps * Time.deltaTime;
	        if(Random.value < t) { ActivatePhone(); }
		}

		if(phoneIsActive && Input.GetKeyDown(KeyCode.P)){ 
			pc.PowerUpLaser();
			pm.AnswerPhone();
		}
	}

	public void DeactivatePhone(){
		phoneIsActive = false;
		pm.PhoneIdle();
	}

	public void ActivatePhone(){
		if(phoneInPlay){
			phoneIsActive = true;
			pm.PhoneRing();
			Invoke("DeactivatePhone", 2f);
		}
	}

	public void AddScore(int points){
		score += points;
		CheckScore();
		sm.SetScore(score);
	}


	public void LoseLife(){
		playerLives --;
		pc.PowerDownLaser();
		if(playerLives < 0){ lm.LoadGameOver(); }
		else{
			lc.RenderClock(playerLives);
			Invoke("Respawn", 0.5f);
		}
	}

	void Respawn(){
		pc.Respawn();
	}

	void LateUpdate(){

		// this disables countdown while screen is hidden
		if(bossIsActive && !screenIsHidden){
			// start countdown to game over
			if(!counting){
				counting = true;
				bm.StartCountdown();
			}
		}else{ 
			bm.StopCountdown(); 
			counting = false;
		}
	}

	void CheckScore(){
		if(score > 300){
			phoneInPlay = true;
		}
		if(score > 600){
			bossInPlay = true;
		}
	}


	void ActivateBoss(){
		if(bossInPlay){
			ToggleBoss();
	        bm.SummonBoss();
	        float bossCount = Random.Range(3f, 6f);
	        Invoke("DeactivateBoss", bossCount);
	    }
	}

	void ToggleBoss(){
		bossIsActive = !bossIsActive;
	}

	void DeactivateBoss(){
		bm.DeSummonBoss();
		Invoke("ToggleBoss", 1f);
	}
}
