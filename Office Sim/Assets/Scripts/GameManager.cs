using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	BossManager bm;
	public float _bps = 0.2f;

	bool bossIsActive = false;

	public GameObject[] formations;
	private GameObject formation;

	// Use this for initialization
	void Start () {
		bm = FindObjectOfType<BossManager>();

		SpawnFormation();
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
		if(formation = null){
			Debug.Log("formation is null");
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
