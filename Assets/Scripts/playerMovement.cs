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

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        jump_scaler = 150;
        playerIsMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        x_movement = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jump_force = new Vector2(0, jump_scaler);
            rb.AddForce(jump_force);
        }
    }
    void FixedUpdate()
    {
        if (rb.velocity.magnitude < max_speed)
        {
            Vector2 movement = new Vector2(x_movement, 0);
            rb.AddForce(movement_scaler * movement);
            playerIsMoving = false;
        } else
        {
            playerIsMoving = true;
        }
    }
}