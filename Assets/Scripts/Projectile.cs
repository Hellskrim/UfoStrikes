using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage;
    public void hit()
    {
        Destroy(gameObject);
    }
    public float getDamaged()
    {
        return damage;
    }
}
