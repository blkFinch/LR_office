using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int damage = 200;

    public bool bonus;

    public int GetDamage()
    {
        return damage;

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "EnemyLaser"){
            Destroy(col.gameObject);
        }
    }

    public void Hit()
    {
       if(!bonus){ Destroy(gameObject); }
    	
    }
}
