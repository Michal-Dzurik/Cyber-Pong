using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour{

    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;
    private int hitCounterBefore;
    public float ballSpeed;
    public GameObject spawnController;
    public RightPlayer playerRigh;
    public LeftPlayer playerLeft;

    public bool playerLeftStarts = true;
    private bool speededUp = false;

    private int hitCounter = 0;
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    private void RestartBall(){
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        playerLeft.Reset();
        playerRigh.Reset();
        stopPowerUpSpeed();
        spawnController.gameObject.GetComponent<Spawn>().onRestart();
        Debug.Log("Chcem plakat");
    }
    
    public IEnumerator Launch(){
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        if(playerLeftStarts){
            MoveBall(new Vector2(-1,-1));
        }

        else MoveBall(new Vector2(1,1));
    }

    public void MoveBall(Vector2 direction){
        direction = direction.normalized;

        if(!speededUp) ballSpeed = startSpeed + hitCounter * extraSpeed;

        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter(){
        if(hitCounter * extraSpeed < maxExtraSpeed){
            hitCounter++;
        }
    }

    public void setPowerUpSpeed(float speed) {
        if (!speededUp)
        {
            hitCounterBefore = hitCounter;
            speededUp = true;

            ballSpeed = speed;
        }
    }

    public void stopPowerUpSpeed() {
        if (speededUp) {
            hitCounter = hitCounterBefore;
            speededUp = false;
        }

    }

}
