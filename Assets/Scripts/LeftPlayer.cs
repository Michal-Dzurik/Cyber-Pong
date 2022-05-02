using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayer : MonoBehaviour
{
    public float racketSpeed;
    private Vector2 originalHeight;

    private Rigidbody2D rb;
    public GameObject player;
    private Vector2 racketDirection;
    private bool reset;
    private bool reverse = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("VerticalLeftPlayer");

        racketDirection = new Vector2(0, reverse ? directionY * (-1) : directionY).normalized;
        if(reset){
            reset = !reset;
            player.transform.position = new Vector2(-7.5f,0);
            
        }
    
    }

    private void FixedUpdate() {
        rb.velocity = racketDirection * racketSpeed;
    }

    public void EnableReverse(){
        this.reverse = true;
    }

    public void DisbaleReverse(){
        this.reverse = false;
    }

    public void Reset(){
        reverse = false;
        reset = true;
    }

    public void MakePlatformSmall(){
        this.gameObject.GetComponent<Transform>().localScale = new Vector2(90.05234F, 60.05234F);
    }

    public void ResetPlatformSmall()
    {
        this.gameObject.GetComponent<Transform>().localScale = new Vector2(90.05234F, 90.05234F);
    }
}
