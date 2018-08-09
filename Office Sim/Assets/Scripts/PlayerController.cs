using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float _speed;
	public int _laserSpeed = 1;
	public GameObject _laser;
	
	// clamp ship movement to screen
	public float ymin = -3.71f; 
	public float ymax =-1.63f;

	float axis;

	private LevelManager lm;

	// Use this for initialization
	void Start () {
		lm = FindObjectOfType<LevelManager>();

	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "EnemyLaser"){
			lm.LoadGameOver();
		}
	}

	//fires laser
    void Fire()
    {
        GameObject beam = Instantiate(_laser, transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector2(1f * _laserSpeed, 0f);
    }
	
	// Update is called once per frame
	void Update () {

		axis = Input.GetAxis("Vertical");

		if( axis < 0 && transform.position.y > ymin ) { transform.position += Vector3.down * _speed; }
		if( axis > 0  && transform.position.y < ymax ) { transform.position += Vector3.up * _speed; }

		if(Input.GetButtonDown("Fire1")){ Fire(); }
		// float newY = Mathf.Clamp(transform.position.y,ymin, ymax);
  //       transform.position = new Vector2(transform.position.x,newY);
		
	}
}
