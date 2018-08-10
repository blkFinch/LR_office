using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	BossManager bm;
	public float _bps = 0.2f;

	bool bossIsActive = false;

	// Use this for initialization
	void Start () {
		bm = FindObjectOfType<BossManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!bossIsActive){
			float p = _bps * Time.deltaTime;

	        if(Random.value < p) { ActivateBoss(); }
		}
	}

	void ActivateBoss(){
		ToggleBoss();
        bm.SummonBoss();
        Invoke("DeactivateBoss", 2f);
	}

	void ToggleBoss(){
		bossIsActive = !bossIsActive;
	}

	void DeactivateBoss(){
		bm.DeSummonBoss();
		Invoke("ToggleBoss", 1f);
	}
}
