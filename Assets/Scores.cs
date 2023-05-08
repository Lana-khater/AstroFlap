using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Scores : MonoBehaviour
{
    public ScoreManagerScript scoreManager;
    void Start()
    {
        GameObject scoreManagerObj = GameObject.FindWithTag("ScoreManager");
        scoreManager = scoreManagerObj.GetComponent<ScoreManagerScript>();
        // score = 0;
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rocket"))
        {
            scoreManager.addScore(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
