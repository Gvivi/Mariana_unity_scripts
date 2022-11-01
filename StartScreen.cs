using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject screen;
    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        screen.SetActive(true);
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("space") && screen.activeSelf)
        {
            screen.SetActive(false);
            player.SetActive(true);
        }
    }
}
