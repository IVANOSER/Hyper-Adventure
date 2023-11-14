using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    private PlayerHP playerHP;

   // private float healthPoint;
    void Start()
    {
       // healthPoint = healthBar.value;
        playerHP = GetComponentInParent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        Damaged();
    }

    void Damaged()
    {
        healthBar.value = playerHP.healthP;
    }
}
