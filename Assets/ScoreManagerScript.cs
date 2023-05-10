using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour //singleton accessable: //firgure out how to connect this to addressables
{
    public int playerScore;
  [SerializeField] public Text scoreText;

    private static ScoreManagerScript instance;
    void Start()
    {
        instance = this;
        playerScore = 0;
        UpdateScoreText();
        //  score = 0;
    }
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        UpdateScoreText();
       // instance.playerScore += scoreToAdd;
        //instance.UpdateScoreText();
        //playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        Debug.Log("Score updated to: " + playerScore.ToString()); //Wrong Fix 
    }
   
   void UpdateScoreText() //For UI
    {
        if (scoreText != null)
        {
            scoreText.text = "" + playerScore.ToString();
        }
        
    }
    void Update()
    {
        
    }
}
