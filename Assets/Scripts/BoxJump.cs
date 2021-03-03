using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : MonoBehaviour
{

    private Rigidbody rb;
    public float[] force;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //example does nothing
    /*int x = 0;
    GameObject[] example = new GameObject[3];
    if(x >= example.Length)
    */

    void Update()
    
    {
        
        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
           
            Debug.Log("Jump");

            //Box goes up
            rb.AddForce(Vector3.up * force[0]);

            
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            Debug.Log("left");

            //Box goes up
            rb.AddForce(Vector3.left * force[0]);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            Debug.Log("right");

            //Box goes up
            rb.AddForce(Vector3.right * force[0]);
        }






    }
}
