using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

[RequireComponent(typeof(Rigidbody))] //link it

public class PlayerControls : MonoBehaviour
{
    public Rigidbody myRigidbody;
   //public float flapStrength;
    [SerializeField] private float flapSpeed; // FS
    [SerializeField] private ForceMode flapMode;
    [SerializeField] private float gravityy = 5f;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight= 5f;
    public bool birdisLive = true;
    public GameObject Rocks;
    public int score = 0;
    public MainMenuScript logic;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.touchCount > 0 && //Touch Screen For Mobile
        //    Input.GetTouch(0).phase == TouchPhase.Began &&
        //    transform.position.y <= maxHeight &&
        //    transform.position.y >= minHeight &&
        //    birdisLive == true) { };

        if (Input.GetKeyDown(KeyCode.Space) == true && 
            transform.position.y <= maxHeight &&
            transform.position.y >= minHeight &&
            birdisLive == true)
        {
            myRigidbody.AddForce (Vector3.up * flapSpeed, flapMode);
         
        }
        myRigidbody.AddForce(Vector3.down * gravityy);
    }
    private void OnTriggerEnter(Collider other)
    {
     
       if (other.gameObject.CompareTag("Rocks"))
        {
            birdisLive = false;
        }
        else 
        if (other.gameObject.CompareTag("Score"))
        {
            score++;
            Debug.Log("Score:" + score);
        }
    }
    private void OnCollisionEnter(Collision collision) //non-triggercollisions
    {
        if (collision.gameObject.CompareTag("Rocks"))
      //  if (collision.gameObject.tag == "Rocks") 
        {
           
            birdisLive = false;
            logic.gameOver();
        }
        
      //  Debug.Log(OnCollisionEnter);
    }
}
