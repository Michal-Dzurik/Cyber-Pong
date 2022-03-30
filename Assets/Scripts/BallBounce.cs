using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    // Start is called before the first frame update
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    private string whoBouncedTheBall = "";
    public GameObject hitSound;
    public LeftPlayer leftPlayerMovement;
    public RightPlayer rightPlayerMovement;
    public GameObject rightProgressBar, leftProgressBar;


    // Constans
    private const string PLAYER_RIGHT = "Right Player";
    private const string PLAYER_LEFT = "Left Player";
    private const string LEFT_BORDER = "Left Border";
    private const string RIGHT_BORDER = "Right Border";
    private const string CHANGE_CONTROL = "Change Controls Power-up";
    private const string TWO_BALLS = "Two Balls Power-up";

    private GameObject powerUp;
    private void Bounce(Collision2D collision){
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;

        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == PLAYER_LEFT){
            positionX = 1;
        }
        else{
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX,positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.name);
        switch(collision.gameObject.name){
            case PLAYER_LEFT:
                Debug.Log(PLAYER_LEFT);
                whoBouncedTheBall = PLAYER_LEFT;
                Bounce(collision);
                break;
            case PLAYER_RIGHT:
                whoBouncedTheBall = PLAYER_RIGHT;
                Debug.Log(PLAYER_RIGHT);
                Bounce(collision);
                
                break;
            case RIGHT_BORDER:
                scoreManager.PlayerLeftScored();
                ballMovement.playerLeftStarts = false;
                StartCoroutine(ballMovement.Launch());
                RestartPowerUps();
                break;
            case LEFT_BORDER:
                scoreManager.PlayerRightScored();
                ballMovement.playerLeftStarts = true;
                StartCoroutine(ballMovement.Launch());
                RestartPowerUps();
                break;
            
        }

        Instantiate(hitSound,transform.position,transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag.Equals(CHANGE_CONTROL)){
            if(!whoBouncedTheBall.Equals("")){
                    Debug.Log("Here we are alsooo");
                    if(whoBouncedTheBall.Equals(PLAYER_LEFT)){
                        //Destroy(collider.gameObject);
                        rightPlayerMovement.EnableReverse();
                        StartCoroutine(PowerUpCooldownRightPlayer());
                        whoBouncedTheBall = "";
                        rightProgressBar.gameObject.SetActive(true);
                        rightProgressBar.GetComponent<PowerUpProgressBar>().TimerStart();
                    }
                    else{
                        //Destroy(collider.gameObject);
                        
                        leftPlayerMovement.EnableReverse();
                        StartCoroutine(PowerUpCooldownLeftPlayer());
                        whoBouncedTheBall = "";
                        leftProgressBar.gameObject.SetActive(true); 
                        leftProgressBar.GetComponent<PowerUpProgressBar>().TimerStart();
                    }

                
                collider.gameObject.GetComponent<Fade>().fadeOut();
            }

            powerUp = collider.gameObject;
        }
        if (collider.gameObject.tag.Equals(TWO_BALLS)) {

            // two balls power up
            if (!whoBouncedTheBall.Equals(""))
            {
                powerUp = collider.gameObject;

            }
        }
    }

    private void RestartPowerUps() {
        leftProgressBar.GetComponent <PowerUpProgressBar>().TimerStop();
        rightProgressBar.GetComponent <PowerUpProgressBar>().TimerStop();
    }

    private IEnumerator PowerUpCooldownLeftPlayer(){
        yield return new WaitForSeconds(5.0f);
        leftPlayerMovement.DisbaleReverse();
    }

    private IEnumerator PowerUpCooldownRightPlayer(){
        yield return new WaitForSeconds(5.0f);
        rightPlayerMovement.DisbaleReverse();
    }
    
}
