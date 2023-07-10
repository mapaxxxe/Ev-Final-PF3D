using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player : MonoBehaviour
{
    public float speed = 5f;
    public bool canmove = false;
    public float life;
    public float actuallife;
    

    private Rigidbody rb;
    

    private void Start()
    {
       
        actuallife = actuallife + life;
        if(canmove == true)
        {
            rb = GetComponent<Rigidbody>();
        }
        
    }

    private void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.velocity = movement * speed;

       
    }

    public void takedamege()
    {
        actuallife = actuallife - 1;
    }
}


