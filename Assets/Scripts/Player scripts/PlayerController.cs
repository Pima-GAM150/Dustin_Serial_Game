using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    Rigidbody rb;
    BoxCollider box;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        box = this.GetComponent<BoxCollider>();
    }
    void Update ()
    {
		if(Input.GetAxisRaw("Horizontal")!=0)
        {
            this.transform.Rotate(Vector3.up, 5 * Speed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            this.transform.Translate(Vector3.forward*Speed*Time.deltaTime*Input.GetAxis("Vertical"), Space.Self);
        }
        if (Input.GetAxis("Jump") != 0 && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * 20 * Speed);
    }

    bool IsGrounded ()
    {
        if(this.transform.position.y == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
