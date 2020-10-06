using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choices : MonoBehaviour {
    public GameObject title;
    public GameObject underTitle;
    public GameObject Choice1;
    public GameObject Choice2;

    public void ChoiceOption1() {
        disableHunterUI();
        Debug.Log("Option 1 - fuck warmup.zone");
        Time.timeScale = 1;
    }

    public void ChoiceOption2() {
        disableHunterUI();
        Debug.Log("Option 2 - warmup.zone er godt");
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
