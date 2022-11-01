using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speedSide = 6.0f;

    [SerializeField]
    private float speedUp = 4.0f;

    [SerializeField]
    private GameObject visual;

    [SerializeField]
    private GameObject broke;

    private AudioSource brokeSound;
    private float timer = 1f;
    private float timeLeft;
    private bool sound;
    private bool flip;
    public void setFlip(bool doFlip) { this.flip = doFlip; }
    private float degrees = 5f;
    private float degreesCurrent;

    private void Start()
    {
        visual.SetActive(true);
        broke.SetActive(false);
        timeLeft = timer;
        sound = true;
        brokeSound = GetComponent<AudioSource>();
        flip = false;
        degreesCurrent = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speedUp);

        if (Input.GetKey("a"))
        {
            transform.position += -transform.right * speedSide * Time.deltaTime;

            //player faces moving direction
            visual.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKey("d"))
        {
            transform.position += transform.right * speedSide * Time.deltaTime;

            //player faces moving direction
            visual.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        
        if (this.gameObject.GetComponent<LifeCount>().getDead() || this.gameObject.GetComponent<OxygenSystem>().getDead())
        {
            if (sound)
            {
                brokeSound.Play();
                sound = false;
            }
            
            speedSide = 0f;
            speedUp = 0f;

            visual.SetActive(false);
            broke.SetActive(true);
        }

        if (this.gameObject.GetComponent<VictoryScreen>().getWin())
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0f)
            {
                speedSide = 0f;
                speedUp = 0f;
            }
        }

        if (flip && !visual.gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            degreesCurrent += degrees;
            transform.rotation = Quaternion.Euler(Vector3.forward * degreesCurrent);
        }
        if (flip && visual.gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            degreesCurrent += degrees;
            transform.rotation = Quaternion.Euler(Vector3.forward * -degreesCurrent);
        }
        if (degreesCurrent >= 360f)
        {
            flip = false;
            degreesCurrent = 0f;
        }
    }
}
