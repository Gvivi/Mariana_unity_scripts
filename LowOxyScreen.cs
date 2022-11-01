using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowOxyScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject lowOxy;

    private float timePeriod = 1f;
    private float timeLeft;
    private bool low;

    private void Start()
    {
        lowOxy.SetActive(false);
        low = false;
        timeLeft = timePeriod;
    }

    private void Update()
    {
        if(this.gameObject.GetComponent<OxygenSystem>().current < 2 && !low
           && !this.gameObject.GetComponent<LifeCount>().getDead()
           && !this.gameObject.GetComponent<OxygenSystem>().getDead())
        {
            low = true;
        }

        if (low)
        {
            timeLeft -= Time.deltaTime;

            if(timeLeft > timePeriod / 2)
            {
                lowOxy.SetActive(true);
            }
            else
            {
                lowOxy.SetActive(false);
            }
        }

        if(timeLeft < 0f)
        {
            low = false;
            timeLeft = timePeriod;
        }
    }
}
