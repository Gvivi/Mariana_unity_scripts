using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleParticleR : MonoBehaviour
{
    ParticleSystem ps;
   
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            ps.Play();
                        
        }
    }
}