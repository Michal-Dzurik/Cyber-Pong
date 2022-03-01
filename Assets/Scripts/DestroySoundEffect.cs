using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoundEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject != null)
        {    
            Destroy(gameObject, 1);
        }
    }


}
