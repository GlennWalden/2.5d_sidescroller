using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    float turn;
    public float jumpHeight;
    public float speed;
    public float groundDistance;
    public bool jumpTest;
    bool isGrounded()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, groundDistance))
        {
            jumpTest = true;
            return true;
        }
        else
        {
            jumpTest = false;
            return false;
        }
    }
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        turn = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(transform.InverseTransformDirection(new Vector3(0, 0, -turn * speed)));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded())
            {
                rb.AddRelativeForce(transform.InverseTransformDirection(new Vector3(0, jumpHeight, 0)), ForceMode.VelocityChange);
            }
        }

    }
}
