using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Fra https://www.youtube.com/watch?v=zit45k6CUMk

    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    void Start()
    {
        startpos = transform.position.x;
        // Get the length of the sprite
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        // How far we've moved relate to the camera
        float temp = (cam.transform.position.x) * (1 - parallaxEffect);
        // How far we moved in space
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);  
        

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;     
    }
}
