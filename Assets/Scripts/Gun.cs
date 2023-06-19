using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage;
    public GameObject playerBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(playerBullet, transform.position + transform.right, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,-90)));
        }
    }
}
