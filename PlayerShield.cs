using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    
    [SerializeField]
    private GameObject shield;

    private bool shieldOn;
    public bool getShieldOn() { return this.shieldOn; }

    void Start()
    {
        shieldOn = false;
        shield.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            shieldOn = true;
            shield.SetActive(true);
        }

        if (Input.GetKeyUp("space"))
        {
            shieldOn = false;
            shield.SetActive(false);
        }

        if (this.gameObject.GetComponent<LifeCount>().getDead() || this.gameObject.GetComponent<OxygenSystem>().getDead())
        {
            shield.SetActive(false);
        }
    }
    



    // use this for a timer shield
    /*
    [SerializeField]
    private GameObject shield;

    [SerializeField]
    private float timer = 3f;

    private float timeLeft;
    private bool shieldOn;

    // Start is called before the first frame update
    void Start()
    {
        shieldOn = false;
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !shieldOn)
        {
            shieldOn = true;
            timeLeft = timer;
            shield.SetActive(true);
        }

        if (shieldOn)
        {
            timeLeft -= Time.deltaTime;
        }
        
        if (timeLeft < 0)
        {
            shieldOn = false;
            shield.SetActive(false);
        }
    }
    */
}
