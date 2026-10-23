using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManage : MonoBehaviour
{
    public HealthChangeEventSo barManage;
    public BarChang  barChang;
    private void OnEnable()
    {
        barManage.OnHealthChangeEvent += OnBarChange;
    }
    private void OnDisable()
    {
        barManage.OnHealthChangeEvent -= OnBarChange;
    }

    private void OnBarChange(Character arg0)
    {
        var precent=arg0.nowHealth/arg0.maxHealth;
        barChang?.OnBarChange(precent);
    }
}
