using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public int[] modifiers;
    public float[] modValues;
    private Rigidbody2D rb;
    private Vector3 normalDir;
    private float oc;

    public float speed;
    public GameObject player;

    void Awake()
    {
        normalDir = transform.eulerAngles;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        oc++;

        int i = 0;
        rb.velocity = transform.up * speed;

        foreach (int mod in modifiers)
        {
            if (mod == 1) //sine move
            {
                transform.eulerAngles = normalDir + new Vector3(0,0,(Mathf.Sin(oc*0.01f))*modValues[i]);
            }
            if (mod == 2) //look at player
            {
                Vector3 lastDir = transform.eulerAngles;
                PointAtPlayer();
                transform.eulerAngles += (transform.eulerAngles - lastDir) / modValues[i];
            }

            i++;
        }
    }

    void PointAtPlayer()
    {
        // convert mouse position into world coordinates
        Vector2 playerScreenPosition = player.transform.position;

        // get direction you want to point at
        Vector2 direction = (playerScreenPosition - (Vector2) transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;
    }
}
