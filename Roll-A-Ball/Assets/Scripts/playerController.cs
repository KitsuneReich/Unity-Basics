using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //FixedUpdate called before any physics update. Since movement is used with
    //physics, script will use FixedUpdate
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (horizontal, 0.0f, vertical);


        rb.AddForce(movement * speed);
    }
}
