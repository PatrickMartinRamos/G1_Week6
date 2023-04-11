using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{   
    
    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    } 
    public void GameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void helpscreen()
    {
        SceneManager.LoadScene(2);
    }

}
