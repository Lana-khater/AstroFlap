using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject gameOverScreen;
   // public string MyOriginal = "MyOriginal";
    public void restartGame()
    {
        Debug.Log("Restarting game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
