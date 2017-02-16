using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width;
    public float height;
    public float enemySpeed;
    public float respTime;

    private float minX;
    private float maxX;
    private bool movingLeft = false;
    
    // Use this for initialization
    void Start () {
        Spawner();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minX = leftMost.x;
        maxX = rightMost.x;
	}

    void Update()
    {
        if (movingLeft)
        {
            transform.position += Vector3.left * enemySpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * enemySpeed * Time.deltaTime;
        }

        float rightEdgeOfScreen = transform.position.x + (0.5f * width);
        float leftEdgeOfScreen = transform.position.x - (0.5f * width);

        if (leftEdgeOfScreen < minX)
        {
            movingLeft = false;
        }
        else if (rightEdgeOfScreen > maxX)
        {
            movingLeft = true;
        }
        float shipPos = Mathf.Clamp(this.transform.position.x, minX, maxX);
        transform.position = new Vector3(shipPos, transform.position.y);

        if(allMembersDead())
        {
            Spawner();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    bool allMembersDead()
    {
        foreach (Transform childPosition in transform)
        {
            if (childPosition.childCount > 0)
                return false; 
        }
        return true;
    }
    Transform nextFreePosition()
    {
        foreach (Transform childPosition in transform)
        {
            if (childPosition.childCount == 0)
                return childPosition;
        }
        return null;
    }

    void Spawner()
    {
        Transform freePosition = nextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity);
            enemy.transform.parent = freePosition;
        }
        if(nextFreePosition())
            Invoke("Spawner", respTime);
    }

}
