using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertMeter : MonoBehaviour {

	public Sprite[] meterLevels;
	SpriteRenderer sr;
	bool isActive;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}

	public void ClearMeterSprite(){
		sr.sprite = null;
		isActive = false;
	}

	public void UnlockMeterSprite(){
		isActive = true;
	}

	public void SwapSprite(int x){
		if(isActive){ sr.sprite = meterLevels[x];}
	}
}
