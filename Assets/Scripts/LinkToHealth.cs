using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkToHealth : MonoBehaviour
{
    public Damagable health;
    public Slider bar;

    void Awake()
    {
        bar.maxValue = health.health;
        bar.value = health.health;
    }

    void Update()
    {
        bar.value += (health.health - bar.value)/3;
    }
}
