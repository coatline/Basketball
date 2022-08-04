using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /* if the camera is past a certain point like the goal,
     have the x offset change to 0 or maybe make it back
    up some by making it negative */

    //maybe do the same for the z offset on the corners?

    public Transform playerTransform;
    public float x = 2;
    public Vector3 offset = new Vector3(0, 5, -10);
    public Transform goal;

    void Start()
    {

    }


    void LateUpdate()
    {

        Vector3 offset = new Vector3(x, 5, -10);
        transform.position = playerTransform.position + offset;

        if (playerTransform.position.x > goal.position.x - 2 && x <= 2)
        {
            //moves the offset to where the camera moves left so that the player can see the goal
            if (x > 0)
                x -= 0.01f;

            if (x < 0)
                x = 0;
        }
        else if (playerTransform.position.x < goal.position.x && x >= 0)
        {
            //moves the offset to where the camera moves right so that the player can see the goal
            if (x < 2)
            {
                x += 0.01f;
            }
            //this catches any errors that it might make
            if (x > 2)
                x = 2;
        }

        //else if (playerTransform.position.x < goal.position.x - 6)
        //{

        //    if (x < 6)
        //    {
        //        x += 0.01f;
        //    }
        //    Debug.Log("f");
        //    if (x > 6)
        //    {
        //        x = 6;
        //    }
        //}
    }


}
