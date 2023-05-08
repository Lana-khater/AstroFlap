using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    { }
    public float speed = 1f; 


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
