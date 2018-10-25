using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetAxis("Horizontal")!=0)
        {

        }
        if (Input.GetAxis("Vertical") != 0)
        {

        }
        if (Input.GetAxis("Jump") != 0)
        {
            Jump();
        }
    }

    void Jump()
    {

    }
}
