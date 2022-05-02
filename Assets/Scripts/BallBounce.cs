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
    public GameObject spawnController;

    private bool shoot = false;


    // Constans
    private const string PLAYER_RIGHT = "Right Player";
    private const string PLAYER_LEFT = "Left Player";
    private const string LEFT_BORDER = "Left Border";
    private const string RIGHT_BORDER = "Right Border";
    private const string CHANGE_CONTROL = "Change Controls Power-up";
    private const string SHRINK = "Shrink Power-Up";
    private const string SPEED_BALL = "Speed The Ball Power-Up";

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
                //Debug.Log(PLAYER_LEFT);
                whoBouncedTheBall = PLAYER_LEFT;
                if (shoot)
                {
                    GetComponent<BallMovement>().setPowerUpSpeed(25f);
                    shoot = false;
                }
                else {
                    PowerUpSpeedStop();
                }
                Bounce(collision);
                break;
            case PLAYER_RIGHT:
                whoBouncedTheBall = PLAYER_RIGHT;
                //Debug.Log(PLAYER_RIGHT);
                if (shoot)
                {
                    GetComponent<BallMovement>().setPowerUpSpeed(25f);
                    shoot = false;
                }
                else
                {
                    PowerUpSpeedStop();
                }
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
                    //Debug.Log("Here we are alsooo");
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
                spawnController.gameObject.GetComponent<Spawn>().IsDestroyed();
                
            }

            powerUp = collider.gameObject;
        }
        if (collider.gameObject.tag.Equals(SPEED_BALL))
        {

            // speed ball power up
            if (!whoBouncedTheBall.Equals(""))
            {
                
               collider.gameObject.GetComponent<Fade>().fadeOut();
                spawnController.gameObject.GetComponent<Spawn>().IsDestroyed();
                shoot = true;

            }
            powerUp = collider.gameObject;
        }
        if (collider.gameObject.tag.Equals(SHRINK))
        {

            if (!whoBouncedTheBall.Equals(""))
            {
                //Debug.Log("Here we are alsooo");
                if (whoBouncedTheBall.Equals(PLAYER_LEFT))
                {
                    //Destroy(collider.gameObject);
                    
                    rightPlayerMovement.MakePlatformSmall();
                    StartCoroutine(PowerUpCooldownRightPlayer());
                    whoBouncedTheBall = "";
                    rightProgressBar.gameObject.SetActive(true);
                    rightProgressBar.GetComponent<PowerUpProgressBar>().TimerStart();
                }
                else
                {
                    //Destroy(collider.gameObject);

                    leftPlayerMovement.MakePlatformSmall();
                    StartCoroutine(PowerUpCooldownLeftPlayer());
                    whoBouncedTheBall = "";
                    leftProgressBar.gameObject.SetActive(true);
                    leftProgressBar.GetComponent<PowerUpProgressBar>().TimerStart();
                }


                collider.gameObject.GetComponent<Fade>().fadeOut();
                spawnController.gameObject.GetComponent<Spawn>().IsDestroyed();
                StartCoroutine(ResetPlatformsDealyed());

            }

            powerUp = collider.gameObject;
        }

    }

    private void RestartPowerUps() {
        leftProgressBar.GetComponent <PowerUpProgressBar>().TimerStop();
        rightProgressBar.GetComponent <PowerUpProgressBar>().TimerStop();

        ResetPlatforms();
    }

    private IEnumerator PowerUpCooldownLeftPlayer(){
        yield return new WaitForSeconds(5.0f);
        leftPlayerMovement.DisbaleReverse();
    }

    private IEnumerator PowerUpCooldownRightPlayer(){
        yield return new WaitForSeconds(5.0f);
        rightPlayerMovement.DisbaleReverse();
    }

    private void PowerUpSpeedStop()
    {
        GetComponent<BallMovement>().stopPowerUpSpeed();
    }

    private IEnumerator ResetPlatformsDealyed()
    {
        yield return new WaitForSeconds(5.0f);
        leftPlayerMovement.ResetPlatformSmall();
        rightPlayerMovement.ResetPlatformSmall();

    }

    private void ResetPlatforms()
    {
        leftPlayerMovement.ResetPlatformSmall();
        rightPlayerMovement.ResetPlatformSmall();

    }

}
