using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarChang : MonoBehaviour
{
    public Image green;
    public Image read;
    public float factor;
    private void Awake()
    {
        read.fillAmount=green.fillAmount;
    }
    private void Update()
    {
        if (read.fillAmount > green.fillAmount)
        {
            read.fillAmount-=Time.deltaTime*factor;
        }
        if(read.fillAmount < green.fillAmount)
        {
            read.fillAmount = green.fillAmount;
        }
    }
    public void OnBarChange(float precent)
    {
        green.fillAmount = precent;
    }
}
