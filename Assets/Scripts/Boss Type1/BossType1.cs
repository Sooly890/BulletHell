using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossType1 : MonoBehaviour
{
    public GameObject redBullet;
    public GameObject yellowBullet;
    public GameObject cyanBullet;
    public GameObject cyanRoundingBullet;
    public GameObject redRoundingBullet;
    public GameObject yellowFollowingBullet;
    public GameObject player;

    private float time;
    private float homingTime;

    void Start()
    {
        
    }
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        homingTime += Time.deltaTime;

        PointAtPlayer();

        if (time > 1.5)
        {
            time = 0;
            Instantiate(cyanRoundingBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,180)));
            Instantiate(redRoundingBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,180)));
            Instantiate(cyanRoundingBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,90)));
            Instantiate(redRoundingBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,90)));
            Instantiate(cyanRoundingBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,-90)));
            Instantiate(redRoundingBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,-90)));
            Instantiate(cyanRoundingBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,0)));
            Instantiate(redRoundingBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,0)));

            Instantiate(yellowBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,45)));
            Instantiate(cyanBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,-45)));
            Instantiate(redBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,135)));
            Instantiate(redBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,-135)));
        }

        if (homingTime > 10)
        {
            Instantiate(yellowFollowingBullet, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,0)));
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
