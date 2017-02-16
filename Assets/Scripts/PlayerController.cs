using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float shipSpeed;
    public float bulletSpeed;
    public float fireRate;
    public GameObject bullet;
    public float health;
    public AudioClip fireSound;
    

    float maxX;
    float minX;
    float bounds = 0.3f;
    

    // Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minX = leftMost.x + bounds;
        maxX = rightMost.x - bounds;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * shipSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * shipSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("fire", 0.00001f, fireRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("fire");
        }

        float shipPos = Mathf.Clamp(this.transform.position.x, minX, maxX);
        transform.position = new Vector3(shipPos, transform.position.y);
    }

    void fire()
    {
        
        Vector3 atShip = new Vector3(0, 0.5f);
        GameObject shots = Instantiate(bullet, this.transform.position + atShip, Quaternion.identity);
        shots.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
        
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missle = collider.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            missle.hit();
            health -= missle.getDamaged();
            if (health <= 0) playerDie();
        }
    }
    void playerDie()
    {
        LevelManager loadLevel = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        Destroy(gameObject);
        loadLevel.LoadLevel("Win Screen");
    }
}
