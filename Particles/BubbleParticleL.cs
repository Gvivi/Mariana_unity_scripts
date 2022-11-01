using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleParticleL : MonoBehaviour
{
    ParticleSystem ps;
   
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {

            ps.Play();
                        
        }
    }
}