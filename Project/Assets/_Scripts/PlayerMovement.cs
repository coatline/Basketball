using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float turnSpeed;
    public float moveSpeed;

    void Awake()
    {
       //Rigidbody myRB = GetComponent<Rigidbody>();
    }

	void Start () {
		
	}




    void Update () {
        
        //make a button to click on or something

        if (Input.GetKey("z"))
        {
            turnSpeed = 150;
        }
        else if (Input.GetKey("x"))
        {
            turnSpeed = 25;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}

