using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    public GameObject kill;
    public float damage = 5f;

    void Awake()
    {
        kill = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == kill)
        {
            kill.GetComponent<Movement>().Damage(damage);

            //Destroy(gameObject);
        }
    }
}
