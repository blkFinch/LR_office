using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int damage = 200;

    public int GetDamage()
    {
        return damage;

    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
