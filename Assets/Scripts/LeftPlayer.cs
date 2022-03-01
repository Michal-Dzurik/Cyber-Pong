using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayer : MonoBehaviour
{
    public float racketSpeed;

    private Rigidbody2D rb;
    public GameObject player;
    private Vector2 racketDirection;
    private bool reset;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("VerticalLeftPlayer");

        racketDirection = new Vector2(0, directionY).normalized;
        if(reset){
            reset = !reset;
            player.transform.position = new Vector2(-7.5f,0);
            
        }
    
    }

    private void FixedUpdate() {
        rb.velocity = racketDirection * racketSpeed;
    }

    public void Reset(){
       reset = true;
    }
}
