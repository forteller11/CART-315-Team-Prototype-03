using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movement_scaler;
    public float jump_scaler;
    public float max_speed;
    public float x_movement;

    public int abilityIndex;

    public bool playerIsMoving;

    public Rigidbody2D rb;
    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerIsMoving = false;
        abilityIndex = 0;
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
        if (Input.GetButtonDown("Action"))
        {
            switch (abilityIndex)
            {
                case 0:
                    useAbility1();
                    break;
                case 1:
                    useAbility2();
                    break;
                case 2:
                    useAbility3();
                    break;
            }
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

            if (x_movement < 0)
            {
                playerAnim.SetBool("isWalkingAhead", false);
                playerAnim.SetBool("isWalkingBack", true);
            }
            else
            {
                playerAnim.SetBool("isWalkingAhead", true);
                playerAnim.SetBool("isWalkingBack", false);
            }
        } else
        {
            playerAnim.SetBool("isWalkingAhead", false);
            playerAnim.SetBool("isWalkingBack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        abilityIndex++;
        abilityIndex = abilityIndex % 3;
        Debug.Log(abilityIndex);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("also working");
    }

    void useAbility1()
    {
        // This allows jumping/levitating
        Debug.Log("you used 1");
        Vector2 jump_force = new Vector2(0, jump_scaler);
        rb.AddForce(jump_force);
    }

    void useAbility2()
    {
        // This would allow combining? if an item thowing mechanic or something similar is added
        Debug.Log("you used 2");
    }

    void useAbility3()
    {
        // This allows ???
        Debug.Log("you used 3");
    }
}