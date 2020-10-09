using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandmaEnter : MonoBehaviour
{
    public GameObject grandmaToggle;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && SceneManager.GetActiveScene().name == "Level_1") {
            grandmaToggle.SetActive(true);
            
            if (Input.GetKey(KeyCode.E)) {
                FindObjectOfType<AudioManager>().Stop("background-tut");
                FindObjectOfType<AudioManager>().Play("doorOpen");
                SceneManager.LoadScene("Level_2");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        grandmaToggle.SetActive(false);
    }
}
