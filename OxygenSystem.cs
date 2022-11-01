using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] oxygen;

    [SerializeField]
    private float timer = 3f;

    [SerializeField]
    private float shieldOnFactor = 3f;

    private float timeLeft;
    public int current;
    private bool dead;
    public bool getDead() { return dead; }

    private void Start()
    {
        current = oxygen.Length-1;
        dead = false;
    }

    private void Update()
    {
        if (this.gameObject.GetComponent<PlayerShield>().getShieldOn())
        {
            timeLeft -= Time.deltaTime * shieldOnFactor;
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }

        if(timeLeft < 0f && !this.gameObject.GetComponent<VictoryScreen>().getWin())
        {
            Loss();
            timeLeft = timer;
        }
    }


    public void Gain()
    {
        if (current < oxygen.Length-1)
        {
            current++;
            oxygen[current].SetActive(true);
        }

        timeLeft = timer;
    }

    public void Loss()
    {
        if(current >= 0)
        {
            oxygen[current].SetActive(false);
            current--;
        }

        if (current < 0)
        {
            dead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Oxygen"))
        {
            Gain();
        }
    }
}
