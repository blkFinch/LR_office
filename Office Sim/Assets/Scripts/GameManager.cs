using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	BossManager bm;
	public float _bps = 0.2f;

	bool bossIsActive = false;
	bool screenIsHidden = false;
	bool counting = false;

	public GameObject[] formations;
	private GameObject formation;

	// Use this for initialization
	void Start () {
		bm = FindObjectOfType<BossManager>();

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

	void LateUpdate(){
		
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
		ToggleBoss();
        bm.SummonBoss();
        Invoke("DeactivateBoss", 3f);
	}

	void ToggleBoss(){
		bossIsActive = !bossIsActive;
	}

	void DeactivateBoss(){
		bm.DeSummonBoss();
		Invoke("ToggleBoss", 1f);
	}
}
