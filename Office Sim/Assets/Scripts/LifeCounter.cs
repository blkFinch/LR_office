using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour {

	public Sprite[] clockPosistions;
	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	//init  clock to 2 to prevent errors
		RenderClock(2);
	}

	public void RenderClock(int x){
		sr.sprite = clockPosistions[x];
	}

}
