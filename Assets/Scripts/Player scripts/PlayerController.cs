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
		if(Input.GetAxisRaw("Horizontal")!=0)
        {
            this.transform.Rotate(Vector3.up, 2 * Speed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            this.transform.Translate(Vector3.forward*Speed*Time.deltaTime*Input.GetAxis("Vertical"), Space.Self);
        }
        if (Input.GetAxis("Jump") != 0)
        {
            Jump();
        }
    }

    void Jump()
    {
        Vector3.Lerp(this.transform.position,this.transform.position + (Vector3.up * Speed ), 2);
    }
}
