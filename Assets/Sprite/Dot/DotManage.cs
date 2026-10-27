using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotManage : MonoBehaviour
{
    public Burns burns { get; private set; }
    public Bleed bleed { get; private set; }   
    public Rupture ruptur { get; private set; }
    public Tremor tremor { get; private set; }
    private Dot[]dots;
    private void OnEnable()
    {
        burns = new Burns();
        bleed = new Bleed();
        ruptur = new Rupture();
        tremor= new Tremor();
        dots =new Dot[] {burns,bleed ,ruptur,tremor};
    }
    private void OnDisable()
    {
        // [修复C] 不再置空：Character / InputControl / Attack 会直接访问这些属性，
        // 置空会在"只禁用组件、不销毁对象"时造成空引用
    }

    private void Update()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i]?.Timer();
        }
    }
}
