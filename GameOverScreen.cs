using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject screen;

    private float timer = 1f;

    private void Start()
    {
        screen.SetActive(false);
    }

    private void Update()
    {

        if ((this.gameObject.GetComponent<LifeCount>().getDead() || this.gameObject.GetComponent<OxygenSystem>().getDead()) &&
            !this.gameObject.GetComponent<VictoryScreen>().getWin())
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0f)
        {
            screen.SetActive(true);
        }

        if (Input.GetKey("space") && screen.activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
