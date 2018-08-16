using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// turn true to begin boss loop
	public bool bossInPlay  = false;
	
	BossManager bm;
	public float _bps = 0.2f;

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
	}

	public void AddScore(int points){
		score += points;
		sm.SetScore(score);
	}


	public void LoseLife(){
		playerLives --;
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
