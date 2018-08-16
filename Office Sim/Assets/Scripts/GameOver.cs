using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	LevelManager lm;
	ScoreManager sm;

	// Use this for initialization
	void Start () {
		lm = FindObjectOfType<LevelManager>();
		sm = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){ 
			if(sm != null){ Destroy(sm.gameObject); }
			lm.LoadTitle(); }
	}
}
