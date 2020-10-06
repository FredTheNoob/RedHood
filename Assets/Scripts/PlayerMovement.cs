using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;
    
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool isInMud;
	bool crouch = false;

	bool hasChosen1 = false;

	// Update is called once per frame
	void Update ()
	{	
		
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (!CutSceneManager.isCutscene) {
            // We lookup our parameter set in the animator called speed, we then parse the horizontalMove speed, and return the absolue (numeriske) value, so that it is always positive
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        } else {
            animator.SetFloat("Speed", Mathf.Abs(0));
        }
		
		if (Input.GetButtonDown("Jump")) {
			if (!CutSceneManager.isCutscene) {
				if (!isInMud) {
					jump = true;
					animator.SetBool("isJumping", true);
					FindObjectOfType<AudioManager>().Play("playerJumpSFX");
				}
			}
		}

		if (Input.GetButtonDown("Crouch")) {
			crouch = true;
		} else if (Input.GetButtonUp("Crouch")) {
			crouch = false;
		} else if (Input.GetKey(KeyCode.R)) {
			int scene = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(scene, LoadSceneMode.Single);
		}
	}

	public void OnLand() {
		animator.SetBool("isJumping", false);
		FindObjectOfType<AudioManager>().Play("playerLandSFX");
	}

	void FixedUpdate () {
		if (!CutSceneManager.isCutscene) {
            // Move our character
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
	}

	private void OnTriggerEnter2D(Collider2D hit) {
        // If we enter the trigger called "Player"
        if (hit.tag == "Mud") {
            runSpeed = runSpeed/2;
			isInMud = true;
		} else if (hit.tag == "MakeChoice1" && !hasChosen1) {
			Time.timeScale = 0;
			FindObjectOfType<Choices>().enableHunterUI();
			hasChosen1 = true;
		}
	}

	private void OnTriggerExit2D(Collider2D hit) {
		// If the player are on the ground or on a obstacle
        if (hit.tag == "Mud") {
            runSpeed = runSpeed * 2;
			isInMud = false;
        }
	}
}