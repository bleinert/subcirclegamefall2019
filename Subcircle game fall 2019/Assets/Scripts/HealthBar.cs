using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthbarslider;
    public Text TxtHealth;
    public int Min;
    public int Max;
    private float mCurrentValue;
    private float mCurrentPercent;
    public PlayerStats playerstats;

    public void SetHealth(float Health)
    {
        if (Health != mCurrentValue)
        {
            if (Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = Health;
                mCurrentPercent = mCurrentValue / (float)(Max - Min);
            }
            TxtHealth.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercent * 100));
            healthbarslider.value = mCurrentPercent;
        }
    }

    private void Update()
    {
        SetHealth(playerstats.playerhealth);

    }

}

