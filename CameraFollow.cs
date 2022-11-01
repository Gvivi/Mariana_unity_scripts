using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Object you want to follow
    [SerializeField]
    private Transform target;

    public void setShake(float shake) { this.shakeAmount = shake; }
    private float shakeAmount = 0f;
    private float decrease = 0.1f;
    private float startX;

    private void Start()
    {
        startX = transform.position.x;
        shakeAmount = 0f;
    }

    private void Update()
    {
        if (shakeAmount > 0)
        {
            transform.position = new Vector3(Random.Range(-shakeAmount, shakeAmount) + startX, Random.Range(-shakeAmount, shakeAmount) + target.position.y, -20);
            shakeAmount -= Time.deltaTime * decrease;

        }
        else
        {
            shakeAmount = 0f;
            transform.position = new Vector3(startX, target.position.y, -20);
        }
    }
}
