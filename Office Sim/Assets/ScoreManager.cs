using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	int score;
	Text scoreDisplay;

	// Use this for initialization
	void Start () {
		scoreDisplay = GetComponentInChildren<Text>();
		DontDestroyOnLoad(this.gameObject);
	}

	public void SetScore(int x){
		score = x;
	}
	
	// Update is called once per frame
	void Update () {
		scoreDisplay.text = score.ToString();
	}
}
