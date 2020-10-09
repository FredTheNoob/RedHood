using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBehaviour : MonoBehaviour
{

    public GameObject paperToggle;

    public GameObject paperZoom;

    bool isReading = false;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player") {
            if (!isReading) paperToggle.SetActive(true);
            
            if (Input.GetKey(KeyCode.E)) {
                FindObjectOfType<AudioManager>().Play("paperSound");
                paperToggle.SetActive(false);
                paperZoom.SetActive(true);
                isReading = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        isReading = false;
        paperToggle.SetActive(false);
        paperZoom.SetActive(false);
    }
}
