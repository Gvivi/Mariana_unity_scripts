using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraeneMove : MonoBehaviour
{
    private float rangeMin;
    private float rangeMax;

    private void Start()
    {
        rangeMin = transform.position.x;
        rangeMax = transform.position.x + 3;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, rangeMax - rangeMin) + rangeMin, transform.position.y, transform.position.z);
    }
}
