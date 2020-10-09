using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CabinEnter : MonoBehaviour
{
    public GameObject cabinToggle;
    public static bool justExited = false;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && SceneManager.GetActiveScene().name == "Level_1") {
            cabinToggle.SetActive(true);
            
            if (Input.GetKey(KeyCode.E)) {
                justExited = false;
                PlayerMovement.startBackgroundSound = false;
                FindObjectOfType<AudioManager>().Stop("background-tut");
                FindObjectOfType<AudioManager>().Play("doorOpen");
                SceneManager.LoadScene("InsideCabin");
            }
        }
        if (other.tag == "Player" && SceneManager.GetActiveScene().name == "InsideCabin") {
            cabinToggle.SetActive(true);

            if (Input.GetKey(KeyCode.E)) {
                SceneManager.LoadScene("Level_1");
                justExited = true;
            }
        } 
    }

    private void OnTriggerExit2D(Collider2D collision) {
        cabinToggle.SetActive(false);
    }
}
