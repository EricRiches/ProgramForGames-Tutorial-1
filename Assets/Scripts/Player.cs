using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 _moveDirection;
    
    public Vector3 jump;
    public float jumpForce = 2.0f;
    bool isGrounded;
    bool isCrouching = false;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InputManager.Init(this);
        InputManager.SetGameControls();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * _moveDirection;

        //check if player is on the ground
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y);
    }

    public void setIsJumping()
    {
        //if player is on the ground then make the player jump
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        
    }
    public void setIsCrouching()
    {
        //if player is not already crouching scale down the player and set isCrouching to true
        if (isCrouching == false)
        {
            transform.localScale -= new Vector3(0, 1, 0); 
            isCrouching = true;
        }
        //if player is crouching then scale up player and set isCrouching to false
        else
        {
            transform.localScale += new Vector3(0, 1, 0); 
            isCrouching = false;
        }
    }

    public void SetMovementDirection(Vector3 currentDirection)
    {
        _moveDirection = currentDirection;
    }
    

}
