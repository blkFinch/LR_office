using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width = 1f;
    public float height = 1f;
    public float speed = 5f;
    public float spawnDelay = 0.5f;
    bool left;

    private float xmax;
    private float xmin;

	// Use this for initialization
	void Start () {
        //initialize enemy movement and sp`eed
        left = true;
        

        //calculate edges
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmin = leftEdge.x;
        xmax = rightEdge.x;

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

    // Update is called once per frame 
    void Update () {
        float rightForm = transform.position.y + (0.5f * width);
        float leftForm = transform.position.y - (0.5f * width);

        if (leftForm > xmin & left) 
        {transform.position += Vector3.up * speed * Time.deltaTime; }
        else { left = false; }

        if (rightForm <xmax & !left)
        {transform.position += Vector3.down * speed*Time.deltaTime;}
        else {left = true;}

        if (AllMembersDead())
        {
            SpawnUntilFull();
        }

    }
}