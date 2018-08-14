using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width = 1f;
    public float height = 1f;
    public float spawnDelay = 0.5f;

    private GameManager gm;

	// Use this for initialization
	void Start () {
        //initialize enemy movement and sp`eed        
        gm = FindObjectOfType<GameManager>();

        SpawnUntilFull();
	}

    void Spawn()
    {
        //spawn enemies
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    void SpawnUntilFull()
    {
        Transform freePos = NextFreePos();
        if (freePos)
        {
          GameObject enemy = Instantiate(enemyPrefab, freePos.position, Quaternion.identity) as GameObject;
          enemy.transform.parent = freePos;
        }
        if (NextFreePos())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(width, height));
    }

    Transform NextFreePos()
    {
        foreach(Transform childPositionGameObject in transform)
        {
            if(childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
                
            }
        }
        return null;
    }

    bool AllMembersDead()
    {
        foreach(Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
            
        }
        return true;
    }

    void DestroyThis(){
        gm.SpawnFormation();
        Destroy(gameObject);
    }

    // Update is called once per frame 
    void Update () {
        
        if (AllMembersDead()){ Invoke("DestroyThis", 1); }
    }
}