using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
    [SerializeField] Text GameOver;
    void Start()
    {
        
    }

    void Update()
    {
        GameObject[] entities = GameObject.FindGameObjectsWithTag("Meteor");
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        if (entities.Length == 0 && player.Length == 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Explosion"));
        }

        if (player.Length == 0 && Input.GetButtonDown("Jump"))
        {
            GameOver.text = "";
            SceneManager.LoadScene("SpaceShipScene");
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            GameOver.text = "Game Paused" + "\n" + "\n" + "\n" +
                "Press Enter to go to Main Menu" + "\n" +
                "Press Space to Resume";
        }

        if (Input.GetButtonDown("Submit") && Time.timeScale == 0)
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
        }

        if (Input.GetButtonDown("Jump") && Time.timeScale == 0)
        {
            GameOver.text = "";
            Time.timeScale = 1;
        }

    }
}
