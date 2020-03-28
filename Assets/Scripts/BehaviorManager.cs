using System;
using System.Collections;
using System.Collections.Generic;
using Behaviors;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class BehaviorManager : MonoBehaviour
{
    public float movement_scaler;
    public float jump_scaler;
    public float max_speed;
    public float x_movement;
    
    [NonSerialized] public JumpBehavior JumpBehavior;
    [NonSerialized] public FireBehavior FireBehavior;
    [NonSerialized] public GrabThrowBehavior GrabThrowBehavior;
    [NonSerialized] public MoveBehavior MoveBehavior;
    [NonSerialized] private List<IBehavior> _behaviors;
    
    Animator modeAlertAnim;
    
    [Flags]
    public enum AbilityModeEnum
    {
        Jump = 0b_0000_0001,
        Fire = 0b_0000_0010,
        GrabThrow = 0b_0000_0100,
        Movement = 0b_0000_1000
    }

    public AbilityModeEnum AbilityMode = AbilityModeEnum.Jump;

    public bool playerIsMoving;

    public Rigidbody2D Rb;
    [FormerlySerializedAs("playerAnim")] public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        JumpBehavior = gameObject.AddComponent<JumpBehavior>();
        JumpBehavior.Script = JumpBehavior;
        
        FireBehavior = gameObject.AddComponent<FireBehavior>();
        FireBehavior.Script = FireBehavior;
        
        GrabThrowBehavior = gameObject.AddComponent<GrabThrowBehavior>();
        GrabThrowBehavior.Script = GrabThrowBehavior;
        
        MoveBehavior = gameObject.AddComponent<MoveBehavior>();
        MoveBehavior.Script = MoveBehavior;
        
        _behaviors = new List<IBehavior>()
        {
            JumpBehavior,
            FireBehavior,
            GrabThrowBehavior,
            MoveBehavior
        };

        foreach (var behavior in _behaviors)
        {
            behavior.Script.enabled = false;
            behavior.BehaviorManager = this;
        }
            
        
        MoveBehavior.enabled = true; //set all behaviors false but movement
        
        modeAlertAnim = GameObject.Find("Mode Alert").GetComponent<Animator>();

        Rb = gameObject.GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        playerIsMoving = false;
        AbilityMode = AbilityModeEnum.Movement;
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO if touching ground, enable jump, else, disable jump
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            playerIsMoving = true;
        } else
        {
            playerIsMoving = false;
        }
        if (Input.GetButtonDown("Action"))
        {
            foreach (var behavior in _behaviors)
                behavior.PerformAction();
            
        } 
    }
    void FixedUpdate()
    {
       
        
//        if(playerIsMoving)
//        {
//            x_movement = Input.GetAxis("Horizontal");
//
//            if (Rb.velocity.magnitude < max_speed)
//            {
//                Vector2 movement = new Vector2(x_movement, 0);
//                Rb.AddForce(movement_scaler * movement);
//            }
//
//            if (x_movement < 0)
//            {
//                Animator.SetBool("isWalkingAhead", false);
//                Animator.SetBool("isWalkingBack", true);
//            }
//            else
//            {
//                Animator.SetBool("isWalkingAhead", true);
//                Animator.SetBool("isWalkingBack", false);
//            }
//        } else
//        {
//            Animator.SetBool("isWalkingAhead", false);
//            Animator.SetBool("isWalkingBack", false);
//        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        modeAlertAnim.SetTrigger("modeSwapped");
//        abilityIndex++;
//        abilityIndex = abilityIndex % 3;
//        Debug.Log($"ability index  + { abilityIndex }");
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
        Rb.AddForce(jump_force);
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