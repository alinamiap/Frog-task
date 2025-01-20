using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public float speed = 5f;
    private Rigidbody rb; 
    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            HandleMovement();
        }

    }


    //Gets input, creates movement vector, applies movement to rb
    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        //Gets camera forward/right dir
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = (cameraForward * moveZ + cameraRight * moveX).normalized * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

    }

    public void SetMovement(bool canMove)
    {
        this.canMove = canMove;
    }
}
