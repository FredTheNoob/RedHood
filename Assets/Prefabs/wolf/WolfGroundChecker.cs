using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfGroundChecker : MonoBehaviour {
    public WolfScript2 wolfscript;
   
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Ground") || collision.CompareTag("Obstacle")) {
            wolfscript.jumping = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Ground")|| collision.CompareTag("Obstacle")) {
            wolfscript.jumping = false;
            wolfscript.jumpObj = collision.gameObject;
        }
    }
}
