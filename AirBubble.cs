using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBubble : MonoBehaviour
{
    private float timer = 0.5f;
    private float timeLeft;
    private bool collision;
    private AudioSource bubbleSound;

    private void Start()
    {
        this.gameObject.GetComponent<Animator>().enabled = false;
        timeLeft = timer;
        collision = false;
    }

    private void Update()
    {
        if (collision)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag.Equals("Player"))
        {
            bubbleSound = GetComponent<AudioSource>();
            this.gameObject.GetComponent<Animator>().enabled = true;
            this.gameObject.GetComponent<Collider2D>().enabled = false;

            collision = true;
            bubbleSound.Play();
        }
    }
}
