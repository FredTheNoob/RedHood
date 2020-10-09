using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScript2 : MonoBehaviour {
    public GameObject Player;
    public GameObject jumpObj;

    float Speed, SpeedLimit, cd;
    Rigidbody2D rb;
    public bool jumping, dashed;
    RaycastHit2D hit2d;
    BoxCollider2D OurCollider;
    public SpriteRenderer spritren;
    public bool SETTING_airjump;
    public GameObject deathText;
    public GameObject deathChoice;

    void Start() {
        Speed = 37;
        SpeedLimit = 7;
        rb = GetComponent<Rigidbody2D>();
        OurCollider = GetComponent<BoxCollider2D>();

        FindObjectOfType<AudioManager>().Play("backgroundMusic");
    }

    void FixedUpdate() {
        if (!jumping) {
            Run();
        }

        if (rb.velocity.x > 0.1f) {
           spritren.flipX = false;
        } else if  (rb.velocity.x < -0.1f) {
            spritren.flipX = true;
        }

        if (jumping) {
            if (rb.velocity.y< 0.2f&&!dashed) {
                rb.AddForce(new Vector3(8*Speed * (new Vector3((Player.transform.position.x - transform.position.x), 0, 0).normalized.x), 0, 0));
                dashed = true;
            }
        }
    }

    private void Run() {
        if (!jumping) {
            rb.AddForce(new Vector3(Speed * (new Vector3((Player.transform.position.x - transform.position.x), 0, 0).normalized.x), 0, 0));
            if (rb.velocity.magnitude > SpeedLimit) { rb.velocity = rb.velocity.normalized * SpeedLimit; }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Obstacle")) {
            if (Player.transform.position.y > transform.position.y) {
                if (SETTING_airjump) {
                    if (jumpObj != collision.gameObject) {
                        jumpObj = collision.gameObject;
                        Jump();
                    }
                } else {
                    if (!jumping) {
                        jumpObj = collision.gameObject;
                        Jump();
                    }
                }
            }
        }
    }

    private void Jump() {
        jumping = true;
        rb.velocity = new Vector3(0,0,0);
        dashed = false;
        rb.AddForce(new Vector3(0, 7+(jumpObj.transform.position.y-transform.position.y), 0),ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D hit) {
        if (hit.gameObject.tag == "Player") {
            Time.timeScale = 0;
            deathText.SetActive(true);
            deathChoice.SetActive(true);
        }
    }
}
