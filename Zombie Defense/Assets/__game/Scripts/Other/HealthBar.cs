using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image health;

    public void UpdateHealThBar(float fraction)
    {
        health.fillAmount = fraction;
    }
}
