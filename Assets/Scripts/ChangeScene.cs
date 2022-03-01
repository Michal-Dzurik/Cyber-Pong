using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MovieToScene(int id){
        SceneManager.LoadScene(id);
    }

    public void Quit(){
        Application.Quit();
    }

    public void Replay(){
        MovieToScene(1);
    }
}
