using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject screen;

    private bool win;
    public bool getWin() { return win; }

    // Start is called before the first frame update
    void Start()
    {
        screen.SetActive(false);
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && screen.activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Finish"))
        {
            win = true;
            screen.SetActive(true);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
