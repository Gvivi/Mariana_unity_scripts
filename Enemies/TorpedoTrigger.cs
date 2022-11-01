using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoTrigger : MonoBehaviour
{
    [SerializeField]
    private float speed = -6.0f;

    [SerializeField]
    private float range = 100f;

    [SerializeField]
    private GameObject visual;

    [SerializeField]
    private GameObject explosion;

    private Vector3 startPosition;
    private bool isMoving;
    private float timer = 2f;
    private AudioSource boom;
    private bool sound;

    private void Start()
    {
        boom = GetComponent<AudioSource>();
        isMoving = false;
        startPosition = transform.position;
        sound = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if (Vector3.Distance(startPosition, transform.position) >= range)
        {
            Destroy(gameObject);
        }


        if (!visual.gameObject.GetComponent<Collider2D>().enabled)
        {
            timer -= Time.deltaTime;
            visual.SetActive(false);
            explosion.SetActive(true);
            if (sound){
            boom.Play();
            sound = false;
        }
         

        }

        if(timer < 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            isMoving = true;
        }
    }
}
