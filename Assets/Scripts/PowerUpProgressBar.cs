using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerUpProgressBar : MonoBehaviour {

    public Slider slider;
    private float time = 5F;

    public void TimerStart() {
        StartCoroutine("Timer");
    }

    public void TimerStop() {
        StopCoroutine("Timer");
        // Not dissapearing really when game scored 
        slider.gameObject.SetActive(false);
    }

    IEnumerator Timer() {
        for (float i = 1; i >= 0; i -= Time.deltaTime / time)
        {
            // set color with i as alpha
            slider.value = i;
            yield return null;
        }

        slider.gameObject.SetActive(false);
    }
}
