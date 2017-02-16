using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public int scoreValue;
    public float health;
    public GameObject bullet;
    public float bulletSpeed;
    public float shotsPerSec;
    public AudioClip fireSound;
    public AudioClip deadSound;


    private ScoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }
    void Update()
    {
        float probability = Time.deltaTime * shotsPerSec;
        if(Random.value < probability) fire();

    }

    void fire()
    {
        Vector3 atShip = new Vector3(0, 0.7f);
        GameObject shots = Instantiate(bullet, this.transform.position - atShip, Quaternion.identity);
        shots.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -bulletSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);    
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missle = collider.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            missle.hit();
            health -= missle.getDamaged();
            if (health <= 0)
            {
                die();
            }
        }
    }
    void die()
    {
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
        AudioSource.PlayClipAtPoint(deadSound, transform.position);
    }
}
