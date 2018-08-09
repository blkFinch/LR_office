using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

    public float laserSpeed; 
    public GameObject laser;
    public float SPS = 0.5f;
    
    public int health = 200;
    // public AudioClip bloop;
    // public AudioClip dead;

    // public GameObject explosion;

    // public Score score;

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit by player collision");
        Laser player_shot = collision.gameObject.GetComponent<Laser>();
        if (player_shot.tag == "Laser")
        {

            player_shot.Hit();
            health -= player_shot.GetDamage();
            if (health <= 0)
            {

                // Instantiate(explosion, transform.position, Quaternion.identity);

                Destroy(gameObject);

                // AudioSource.PlayClipAtPoint(dead, transform.position);
            }
        }
    }

    void fireLaser()
    {

        GameObject beam = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f * laserSpeed, 0f);
    }

   void Update()
    {
        float p = SPS * Time.deltaTime;

        if(Random.value < p)
        {
            fireLaser();
        }
        
        
    }
}
