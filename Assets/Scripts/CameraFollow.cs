using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Create a reference to the player object's transform
    public Transform playerPos;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!CutSceneManager.isCutscene) {
            // Set the cameraposition on the x-axis of the player. This way the camera will not follow the player vertically when he jumps. 
            //We also offset the camera on the z-axis to ensure it is on top
            transform.position = new Vector3(playerPos.position.x, 0,-10);
        }
    }
}
