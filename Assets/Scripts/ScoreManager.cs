using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int playerLeftScore = 0,playerRightScore = 0;

    public Text playerLeftScoreText,playerRightScoreText;
    public Text playerLeftScoreTextPlus,playerRightScoreTextPlus;
    public int maxScoreToReach;

    public void PlayerLeftScored(){
        playerLeftScore++;
        playerLeftScoreText.text = playerLeftScore.ToString();

        //FadeInAnimation fade = new FadeInAnimation(playerLeftScoreTextPlus);
        //fade.startFading();
        CheckScore();

    }

    public void PlayerRightScored(){
        playerRightScore++;
        playerRightScoreText.text = playerRightScore.ToString();

        //FadeInAnimation fade = new FadeInAnimation(playerRightScoreTextPlus);
        //fade.startFading();
        CheckScore();

    }


    IEnumerator FadeOut(){
    while (playerRightScoreTextPlus.color.a > 0)
    {
        playerRightScoreTextPlus.color = Color.Lerp(playerRightScoreTextPlus.color, new Color(1,1,1,1), 200 * Time.deltaTime);
    }

    yield return new WaitForSeconds(2);

    while (playerRightScoreTextPlus.color.a <= 1)
    {
        playerRightScoreTextPlus.color = Color.Lerp(playerRightScoreTextPlus.color, new Color(1,1,1,0), 200 * Time.deltaTime);
    }
    
}

    private void CheckScore(){
        if(playerLeftScore == maxScoreToReach || playerRightScore == maxScoreToReach){
            SceneManager.LoadScene(2);
            Debug.Log("max - " + maxScoreToReach + " current - " + playerLeftScore + "|" + playerRightScore);
        }
    }
}
