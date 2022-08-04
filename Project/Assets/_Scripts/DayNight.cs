using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

    float a = 100f;
    float b = -100f;

    void Awake()
    {
        
    }

	void Start () {
		
	}
	
	void Update () {
        
        transform.rotation = Quaternion.Euler(a, b, 0);

        a += .07f;
        b += .009f;
    }
}
