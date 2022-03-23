using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update7
    [SerializeField] GameObject pauseMenu;
    private bool pauseMenuVisible = false;
    public CursorControler cursorControler;
    public ChangeScene sceneManager;

    void Start(){
    
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
    }

    public void Resume()
    {
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
