using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    public Transform playerPos;
    public GameObject player;
    public Rigidbody2D rb;

    public Transform tpPosition;
    public GameObject deathText;
    public GameObject deathChoice;

    public float speed = 10f;
    public float maxSpeed = 5f;
    public float jumpForce = 10f;

    bool isJumping = false;
    float jumpCooldown;

    // Update is called once per frame
    void FixedUpdate() {
        // The cooldown will decrease over game time
        jumpCooldown -= Time.deltaTime;
        
        // If on the ground -> Add a force on the x-axis only multiplied with a set speed
        if (!CutSceneManager.isCutscene) {
            if (!isJumping) rb.AddForce((new Vector3(player.transform.position.x, transform.position.y, 0) - transform.position).normalized * speed);
        }
    
        // If the velocity exceeds a certain set speed and enemy is on the ground
        if (rb.velocity.magnitude > maxSpeed && !isJumping) {
            // Reset the velocity on the rigidbody, making sure it is constant
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        float distanceBetween = Vector2.Distance(this.transform.position, playerPos.position);

        if (distanceBetween > 15.0f) {
            transform.position = new Vector3(tpPosition.position.x, tpPosition.position.y, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D hit) {
        // If we enter the trigger called "JumpTrigger"
        if (hit.tag == "JumpTrigger") {
            // if the cooldown is less than the threshold
            if (jumpCooldown < -0.2f) {
                // Add a force that makes the enemy jump
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                // Reset the cooldown
                jumpCooldown = 0;
                // The enemy is now in the air
                isJumping = true;
            }   
		}
	}

    // This event checks if an objects stays on a trigger
    private void OnTriggerStay2D(Collider2D hit) {
        // If the enemy are on the ground or on a obstacle
        if (hit.gameObject.CompareTag("Ground") || hit.gameObject.CompareTag("Obstacle")) {
            // We are no longer in air
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D hit) {
        if (hit.gameObject.tag == "Player") {
            Time.timeScale = 0;
            deathText.SetActive(true);
            deathChoice.SetActive(true);
        }
    }
}
