using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour{

    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;
    public float ballSpeed;
    public GameObject spawnController;
    public RightPlayer playerRigh;
    public LeftPlayer playerLeft;

    public bool playerLeftStarts = true;

    private int hitCounter = 0;
    private Rigidbody2D rb,rb2;
    

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb2 = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    private void RestartBall(){
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        playerLeft.Reset();
        playerRigh.Reset();
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

        ballSpeed = startSpeed + hitCounter * extraSpeed;

        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter(){
        if(hitCounter * extraSpeed < maxExtraSpeed){
            hitCounter++;
        }
    }
    public void SpawnBall2() {
        rb2.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }
    public void MoveBall2(Vector2 direction)
    {
        direction = direction.normalized;

        ballSpeed = startSpeed + hitCounter * extraSpeed;

        rb2.velocity = direction * ballSpeed;
    }

}
