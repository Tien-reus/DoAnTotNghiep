using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPBar : MonoBehaviour
{
    public Transform HpBarData;
    public Slider slider;

    private void FixedUpdate()
    {
        UpdateHpBar();
    }

    protected virtual void UpdateHpBar()
    {
        if (this.slider == null) return;
        IHpBarInterface hpBarInterface = this.HpBarData.GetComponent<IHpBarInterface>();
        if (hpBarInterface == null) return;

    }
}
