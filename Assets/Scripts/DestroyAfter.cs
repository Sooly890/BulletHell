using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float time;
    private float dTime = 0;
    void Update()
    {
        dTime += Time.deltaTime;

        if (dTime > time)
        {
            Destroy(gameObject);
        }
    }
}
