using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movement_scaler;
    public float jump_scaler;
    public float max_speed;
    public float x_movement;

    public bool playerIsMoving;
    public bool playerIsOnGround;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        playerIsMoving = false;
        playerIsOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            playerIsMoving = true;
        } else
        {
            playerIsMoving = false;
        }
        if (Input.GetButtonDown("Jump") && playerIsOnGround)
        {
            //Debug.Log("I am responding");
            Vector2 jump_force = new Vector2(0, jump_scaler);
            rb.AddForce(jump_force);
        } 
    }
    void FixedUpdate()
    {
        if(playerIsMoving)
        {
            x_movement = Input.GetAxis("Horizontal");

            if (rb.velocity.magnitude < max_speed)
            {
                Vector2 movement = new Vector2(x_movement, 0);
                rb.AddForce(movement_scaler * movement);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("working");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("also working");
    }
}