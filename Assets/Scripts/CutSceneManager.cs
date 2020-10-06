using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CutSceneManager : MonoBehaviour {
    public static bool isCutscene;
    public Transform camPos;
    public Rigidbody2D rb;
    public Transform point;
    public Transform player;
    private bool ranTestCutscene = false;
    private bool ranTestCutscene2 = false;
 
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (!ranTestCutscene && this.tag == "Cutscene1") {
                //FindObjectOfType<AudioManager>().Play()
                Debug.Log(("TEST 1"));
                ranTestCutscene = true;
                isCutscene = true;
                float extraTime = 1f;
                StartCoroutine(moveCamera(point, extraTime));
                Invoke(nameof(StopCutscene), 3f + extraTime);
            } 
            if (!ranTestCutscene2 && this.tag == "Cutscene2") {
                Debug.Log(("TEST 2"));
                ranTestCutscene2 = true;
                isCutscene = true;
                float extraTime = 2f;
                StartCoroutine(moveCamera(point, extraTime));
                Invoke(nameof(StopCutscene), 3f + extraTime);
            }
        }
    }
 
    void StopCutscene() {
        isCutscene = false;
    }
 
    public IEnumerator moveCamera(Transform point, float animationTime) {
        rb.velocity = Vector3.zero;
        rb.AddForce((new Vector3(point.position.x, 0,-10) - new Vector3(camPos.position.x,0,-10))*215*2/Vector3.Distance(point.position, camPos.position));
        rb.velocity = rb.velocity / 2;
        
        yield return new WaitForSeconds(1.5f);
 
        rb.velocity = Vector3.zero;
 
        // animate me
        Debug.Log("Animation STARTS here!");
 
        yield return new WaitForSeconds(animationTime);
 
        Debug.Log("Animation ENDS here!");
 
        rb.AddForce((new Vector3(player.position.x, 0,-10) - new Vector3(camPos.position.x,0,-10))*215*2/Vector3.Distance(player.position, camPos.position));
        rb.velocity = rb.velocity / 2;
    }
}