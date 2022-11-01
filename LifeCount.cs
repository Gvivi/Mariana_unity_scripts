using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lives;

    [SerializeField]
    private GameObject camera;

    [SerializeField]
    private float shakeFactor = 0.1f;

    private int currentLives;
    private bool dead;
    public bool getDead() { return dead; }

    private void Start()
    {
        currentLives = lives.Length;
        dead = false;
    }

    public void Damage ()
    {
        currentLives--;
        Destroy(lives[currentLives].gameObject);
        camera.GetComponent<CameraFollow>().setShake(shakeFactor);

        if(currentLives < 1)
        {
            dead = true;
        }
        else
        {
            this.gameObject.GetComponent<PlayerMove>().setFlip(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy") && !this.gameObject.GetComponent<PlayerShield>().getShieldOn())
        {
            Damage();
            other.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
