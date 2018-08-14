using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

    public float laserSpeed; 
    public GameObject laser;
    public float SPS = 0.5f;
    
    public int health = 200;

    public Sprite explosion;
    SpriteRenderer sr;
    // public AudioClip bloop;
    // public AudioClip dead;

    // public GameObject explosion;

    public int points = 100;

    GameManager gm;

    // MOVEMENT
    [Range(0,1)]
    public float _speed;
    public bool up = true;
    public float ymax;
    public float ymin;

    private void Start()
    {
       sr = GetComponentInChildren<SpriteRenderer>();
       gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject col = collision.gameObject;

        Debug.Log("trigger" + col.tag);

        if (col.tag == "Laser")
        {
            Laser player_shot = collision.gameObject.GetComponent<Laser>();

            player_shot.Hit();
            health -= player_shot.GetDamage();
            if (health <= 0)
            {

                // Instantiate(explosion, transform.position, Quaternion.identity);
                sr.sprite = explosion;
                Invoke("DestroyEnemy", 0.5f);
                // AudioSource.PlayClipAtPoint(dead, transform.position);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision enter");
        if(col.gameObject.tag == "Enemy"){
            Debug.Log("Enemy trigger");
            EnemyShip enemy = col.gameObject.GetComponent<EnemyShip>();
            SwitchDirection();
        }
    }

    public void SwitchDirection(){
        Debug.Log("Switch Direction");
        up = !up;
    }

    void DestroyEnemy(){
        gm.AddScore(points);
        Destroy(gameObject);
    }

    void fireLaser()
    {

        GameObject beam = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f * laserSpeed, 0f);
    }

   void Update()
    {
        float p = SPS * Time.deltaTime;
        if(Random.value < p){ fireLaser(); }

        float upPos = transform.position.y + (0.1f);
        float downPos = transform.position.y + (0.1f);

        if(upPos < ymax && !up)
        { transform.position += Vector3.up * _speed * Time.deltaTime;}
        else { up = true; }

        if(downPos > ymin && up)
        { transform.position += Vector3.down * _speed * Time.deltaTime;}
        else { up = false; }
        
    }
}
