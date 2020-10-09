using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinEnter : MonoBehaviour
{
    public GameObject cabinEnter;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player") {
            cabinEnter.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E)) {
                Debug.Log("bruh");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        cabinEnter.SetActive(false);
    }
}
