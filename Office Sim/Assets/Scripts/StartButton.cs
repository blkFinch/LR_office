using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	LevelManager lm;

	public bool startsGame;

	void Start(){
		lm = FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag == "Laser" && startsGame){ lm.StartGame(); }
		if(col.gameObject.tag == "Laser" && !startsGame) { lm.LoadControls(); }
	}
}
