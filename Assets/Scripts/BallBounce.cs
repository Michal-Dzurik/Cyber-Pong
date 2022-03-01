using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    // Start is called before the first frame update
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    public GameObject hitSound;
    private void Bounce(Collision2D collision){
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;

        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "Player Left"){
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
        if(collision.gameObject.name == "Player Left" || collision.gameObject.name == "Player Righ"){
                Bounce(collision);
        }
        else if (collision.gameObject.name == "Right Border"){
            scoreManager.PlayerLeftScored();
            ballMovement.playerLeftStarts = false;
            StartCoroutine(ballMovement.Launch());
        }
        else if (collision.gameObject.name == "Left Border"){
            scoreManager.PlayerRightScored();
            ballMovement.playerLeftStarts = true;
            StartCoroutine(ballMovement.Launch());
        }

        Instantiate(hitSound,transform.position,transform.rotation);
    }

    
}
