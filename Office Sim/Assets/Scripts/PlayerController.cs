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
	public float xmax = 5;
	public float xmin = 1;


	float axis;
	float hAxis;

	private LevelManager lm;
	HideGame hg;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		lm = FindObjectOfType<LevelManager>();
		hg = FindObjectOfType<HideGame>();
		rb = GetComponent<Rigidbody2D>();
		_speed = _speed * Time.deltaTime;
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
		hAxis = Input.GetAxis("Horizontal");

		if( axis < 0 && transform.position.y > ymin ) { transform.position += Vector3.down * _speed; }
		if( axis > 0  && transform.position.y < ymax ) { transform.position += Vector3.up * _speed; }
		if( hAxis < 0 && transform.position.x > xmin ) { transform.position += Vector3.left * _speed; }
		if( hAxis > 0  && transform.position.x < xmax ) { transform.position += Vector3.right * _speed; }
		
		if(Input.GetButtonDown("Fire1")){ Fire(); }

		if(Input.GetButtonDown("Fire2")){ hg.Cover(); }
		if(Input.GetButtonUp("Fire2")){ hg.UnCover(); }

		// float newY = Mathf.Clamp(transform.position.y,ymin, ymax);
  //       transform.position = new Vector2(transform.position.x,newY);
		
	}
}
