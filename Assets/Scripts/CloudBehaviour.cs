using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    // This represents a position, where the clouds will be moved to
    public Transform moveToPos;
    // This represents the position of the player
    public Transform playerPos;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the distance between the player and the cloud
        float distanceBetween = Vector2.Distance(this.transform.position, playerPos.position);

        // If the cloud gets outside the camera
        if (distanceBetween > 17.0f)
        {
            // move it in front of the camera, and add a random int on the y-axis. This will make the clouds appear with more randomness
            transform.position = new Vector3(moveToPos.position.x, moveToPos.position.y + Random.Range(-2, 2), 0.0f);
        }
    }
}
