using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D collider){
		Debug.Log("collision detected");
		Destroy(collider.gameObject);
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log("trigger detected");
		Destroy(col.gameObject);
	}

}
