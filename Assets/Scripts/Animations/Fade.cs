using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Fade : MonoBehaviour{
    // the image you want to fade, assign in inspector
    public GameObject thisObject;

    public void fadeIn() {
        StartCoroutine(FadeEffect(true));
    }

    public void fadeOut(){
        StartCoroutine(FadeEffect(false));
    }

    IEnumerator FadeEffect(bool fadeIn){
        // fade from opaque to transparent
        SpriteRenderer texture = thisObject.GetComponent<SpriteRenderer>();
        Color originalColor = texture.color; 
        if (!fadeIn){
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime){
                // set color with i as alpha
                originalColor.a = i;
                texture.color = originalColor;
                yield return null;
            }
            Destroy(thisObject);

        }
        // fade from transparent to opaque
        else{
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime){
                // set color with i as alpha
                originalColor.a = i;
                texture.color = originalColor;
                yield return null;
            }

        
        }
    }
}
