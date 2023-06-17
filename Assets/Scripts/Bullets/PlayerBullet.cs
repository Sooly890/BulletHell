using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float damage;

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.TryGetComponent<Damagable>(out Damagable dm);
        dm.Damage(damage);
    }
}
