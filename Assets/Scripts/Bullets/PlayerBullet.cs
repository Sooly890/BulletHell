using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float damage;
    public float speed;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.TryGetComponent<Damagable>(out Damagable dm);
        if (dm != null)
        {
            dm.Damage(damage);
            Destroy(gameObject);
        }
    }
}
