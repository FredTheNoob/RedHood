using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choices : MonoBehaviour {
    public GameObject title;
    public GameObject underTitle;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject deathText;
    public GameObject deathChoice;

    public void ChoiceOption1() {
        disableHunterUI();
        Time.timeScale = 1;
    }

    public void ChoiceOption2() {
        disableHunterUI();
        Time.timeScale = 1;
    }
    
    public void deathChoiceRestart() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        deathText.SetActive(false);
        deathChoice.SetActive(false);
        Time.timeScale = 1;
    }

    public void disableHunterUI() {
        title.SetActive(false);
        underTitle.SetActive(false);
        Choice1.SetActive(false);
        Choice2.SetActive(false);
    }

    public void enableHunterUI() {
        title.SetActive(true);
        underTitle.SetActive(true);
        Choice1.SetActive(true);
        Choice2.SetActive(true);
    }
}
