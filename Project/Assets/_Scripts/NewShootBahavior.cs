using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShootBahavior : MonoBehaviour {
    
    float percentage;
    float shotSpeed = 3;


    private void Start()
    {
        
    }

    void Shooting()
    {
        percentage += shotSpeed * Time.deltaTime;
    }

    void Shoot()
    {
        if(percentage == 1)
        {
            //make
        }
    }

}
