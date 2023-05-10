using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))] //link it (always attached)

public class PlayerControls : MonoBehaviour
{
    public Rigidbody myRigidbody;
    [SerializeField] private float flapSpeed; // FS
    [SerializeField] private ForceMode flapMode;
    [SerializeField] private float gravityy = 5f;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight= 5f;
    [SerializeField] private GameObject gameOverUI1;
    public bool birdisLive = true;
    public GameObject Rocks;
    public int score = 0;
  //  public MainMenuScript logic;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && //Touch Screen For Mobile
           Input.GetTouch(0).phase == TouchPhase.Began &&
         transform.position.y <= maxHeight &&
         transform.position.y >= minHeight &&
        birdisLive == true)
        {
            myRigidbody.AddForce(Vector3.up * flapSpeed, flapMode);

        }
        myRigidbody.AddForce(Vector3.down * gravityy);
    }

      //  if (Input.GetKeyDown(KeyCode.Space) == true && ///For Testing on Laptop
        //    transform.position.y <= maxHeight &&
          //  transform.position.y >= minHeight &&
            //birdisLive == true)
       
    private void OnTriggerEnter(Collider other) //pass not collide
    {
     
       if (other.gameObject.CompareTag("Rocks"))
        {
            birdisLive = false;
            gameOverUI1.SetActive(true);

        }
        else 
        if (other.gameObject.CompareTag("Score")) //doesnt work
        {
            score++;
            Debug.Log("Score:" + score);
        }
    }
    private void OnCollisionEnter(Collision collision) //non-triggercollisions
    {
       // if (collision.gameObject.name == "Rocks")
            if (collision.gameObject.tag == "Rocks") 
        {
            
            birdisLive = false;
            //SceneManager.LoadSceneAsync("EndScreen");

        }
        //  Debug.Log(OnCollisionEnter);
    }
}
