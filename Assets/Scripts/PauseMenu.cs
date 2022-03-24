using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update7
    [SerializeField] GameObject ball;
    [SerializeField] GameObject pauseMenu;
    private bool pauseMenuVisible = false;
    public CursorControler cursorControler;
    public ChangeScene sceneManager;
    
    private Color transparent;
    private Color white;

    void Start(){
        transparent = new Color(0,0,0,0f);
        white = new Color(1f,1f,1f,1f);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            
            if(pauseMenuVisible) Resume();
            else Pause();
            
        }
       
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseMenuVisible = true;
        cursorControler.Show();
        ball.GetComponent<SpriteRenderer>().color = transparent;
    }

    public void Resume()
    {
        ball.GetComponent<SpriteRenderer>().color = white;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseMenuVisible = false;
        cursorControler.Hide();
        
    }

    public void MainMenu(){
        Resume();
        sceneManager.MainMenu();
    }
}
