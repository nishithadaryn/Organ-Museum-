using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera Camera;


    [Header("Configurations")]
    public float walkSpeed  = 5f;
    public float runSpeed = 10f;

    public float mouseSensitivity = 2f;
    public float lookXLimit = 80f;
    public float verticalSpeed;


    [Header("Runtime")]
    Vector3 newVelocity;

   
    void Start()
    {
    
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

 
    void Update()
    {
     
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);  

        newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;

        rb.velocity = transform.TransformDirection(newVelocity);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

       
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);

        
        float Speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
       

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            moveDirection += transform.up;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            moveDirection -= transform.up;
        }

        moveDirection.y = 0; 
        Vector3 move = moveDirection.normalized * speed * Time.deltaTime;

   
    }
}