using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pufferFish : MonoBehaviour
{
    [SerializeField]
    private GameObject animationLayer;

    private AudioSource pufferSound;
    private bool sound;

    private void Start()
    {
        animationLayer.gameObject.GetComponent<Animator>().enabled = false;
        pufferSound = GetComponent<AudioSource>();
        sound = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            animationLayer.gameObject.GetComponent<Animator>().enabled = true;

            if (sound)
            {
                pufferSound.Play();
                sound = false;
            }
        }
    }
}