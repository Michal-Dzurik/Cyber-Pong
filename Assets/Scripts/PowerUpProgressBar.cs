using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerUpProgressBar : MonoBehaviour {

    private Slider slider;
    private float progress;
    private float time = 5F;

    private void Awake() { 
        slider = gameObject.GetComponent<Slider>();
    }

    public void TimerStart() {
        StartCoroutine("Timer");
    }

    public void TimerStop() {
        StopCoroutine("Timer");
        // Not dissapearing really when game scored 
    }

    IEnumerator Timer() {
        for (float i = 1; i >= 0; i -= Time.deltaTime / 5)
        {
            // set color with i as alpha
            slider.value = i;
            yield return null;
        }

        slider.gameObject.SetActive(false);
    }
}
