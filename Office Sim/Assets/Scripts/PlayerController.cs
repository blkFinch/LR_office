using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float _speed;
	public int _laserSpeed = 1;
	public GameObject[] lasers;
	int activeLaser;
	
	// clamp ship movement to screen
	public float ymin = -3.71f; 
	public float ymax =-1.63f;
	public float xmax = 5;
	public float xmin = 1;


	float axis;
	float hAxis;

	public AudioClip zap;

	
	HideGame hg;
	Rigidbody2D rb;

	SpriteRenderer sr;
	public Sprite dead;
	public Sprite ship;

	bool isDead;

	GameManager gm;
	// Use this for initialization
	void Start () {
		
		hg = FindObjectOfType<HideGame>();
		rb = GetComponent<Rigidbody2D>();
		gm = FindObjectOfType<GameManager>();
		sr = GetComponentInChildren<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "EnemyLaser" && !isDead){
			PlayerDestroyed();
		}
	}

	public void PlayerDestroyed(){
		isDead = true;
		sr.sprite = dead;
		gm.LoseLife();
	}

	public void Respawn(){
		sr.sprite = ship;
		isDead = false;
	}

	//the laser array is set publically so be aware
	//First laser in array is default
	public void PowerUpLaser(){
		activeLaser = 1;
	}

	public void PowerDownLaser(){
		activeLaser = 0;
	}

	//fires laser
    void Fire()
    {
    	AudioSource.PlayClipAtPoint(zap,  transform.position);
        GameObject beam = Instantiate(lasers[activeLaser], transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector2(1f * _laserSpeed, 0f);
    }
	
	// Update is called once per frame
	void Update () {

		axis = Input.GetAxis("Vertical");
		hAxis = Input.GetAxis("Horizontal");
		if(!isDead){
			if( axis < 0 && transform.position.y > ymin ) { transform.position += Vector3.down * _speed * Time.deltaTime; }
			if( axis > 0  && transform.position.y < ymax ) { transform.position += Vector3.up * _speed * Time.deltaTime; }
			if( hAxis < 0 && transform.position.x > xmin ) { transform.position += Vector3.left * _speed * Time.deltaTime; }
			if( hAxis > 0  && transform.position.x < xmax ) { transform.position += Vector3.right * _speed * Time.deltaTime; }
			
			if(Input.GetButtonDown("Fire1")){ Fire(); }

			if(Input.GetButtonDown("Fire2")){ hg.Cover(); }
			if(Input.GetButtonUp("Fire2")){ hg.UnCover(); }
		}
		// float newY = Mathf.Clamp(transform.position.y,ymin, ymax);
  //       transform.position = new Vector2(transform.position.x,newY);
		
	}
}
