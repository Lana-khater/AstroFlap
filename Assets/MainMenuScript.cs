using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI1;

    void Start()
    {
       gameOverUI1.SetActive(false);

    }
    // private void OnCollisionEnter(Collision collision) 
    //{
    //  Debug.Log("Collision detected with " + collision.gameObject.name);
    //if (collision.gameObject.tag == "Rocks")
    //{

    //  gameOverUI1.SetActive(true);
    //SceneManager.LoadSceneAsync("EndScreen");

    //  }
   public void restartGame()
        {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("StartScreen");
       }
    
}
