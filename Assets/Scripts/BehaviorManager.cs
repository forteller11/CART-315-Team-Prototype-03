﻿using System;
using System.Collections;
using System.Collections.Generic;
using Behaviors;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]

[RequireComponent(typeof(JumpBehavior))]
[RequireComponent(typeof(FireBehavior))]
[RequireComponent(typeof(GrabThrowBehavior))]
[RequireComponent(typeof(MoveBehavior))]
public class BehaviorManager : MonoBehaviour
{
    private float _horizontalInput;
    private SpriteRenderer _spriteRenderer;
    Animator modeAlertAnim;
    Animator exitAlertAnim;

    [NonSerialized] public JumpBehavior JumpBehavior;
    [NonSerialized] public FireBehavior FireBehavior;
    [NonSerialized] public GrabThrowBehavior GrabThrowBehavior;
    [NonSerialized] public MoveBehavior MoveBehavior;
    [NonSerialized] private List<IBehavior> _behaviors;
    
    
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
    
    [HideInInspector] public Rigidbody2D Rb;

    public bool actionFlag1Activated = false;
    public bool actionFlag2Activated = false;

    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        #region init behaviors
        JumpBehavior = gameObject.GetComponent<JumpBehavior>();
        JumpBehavior.Script = JumpBehavior;
        
        FireBehavior = gameObject.GetComponent<FireBehavior>();
        FireBehavior.Script = FireBehavior;
        
        GrabThrowBehavior = gameObject.GetComponent<GrabThrowBehavior>();
        GrabThrowBehavior.Script = GrabThrowBehavior;
        
        MoveBehavior = gameObject.GetComponent<MoveBehavior>();
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
            behavior.Activated = false;
            behavior.BehaviorManager = this;
        }
        
        MoveBehavior.Activated = true; //set all behaviors false but...
        JumpBehavior.Activated = true;
        GrabThrowBehavior.Activated = true;
        
        #endregion
        
        modeAlertAnim = GameObject.Find("Mode Alert").GetComponent<Animator>();
        exitAlertAnim = GameObject.Find("Exit Alert").GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Rb = gameObject.GetComponent<Rigidbody2D>();
        playerIsMoving = false;
        AbilityMode = AbilityModeEnum.Movement;

        tower = GameObject.Find("Tower");
        tower.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO if touching ground, enable jump, else, disable jump
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            playerIsMoving = true;
            actionFlag1Activated = true;

        } else
        {
            playerIsMoving = false;
        }
        
        if (Input.GetButtonDown("Action"))
        {
            foreach (var behavior in _behaviors)
            {
                if (behavior.Activated)
                    behavior.OnActionPress();
            }
        } 
        
        if (Input.GetButtonUp("Action"))
        {
            foreach (var behavior in _behaviors)
            {
                if (behavior.Activated)
                    behavior.OnActionRelease();
            }
            if (actionFlag1Activated)
            {
                actionFlag2Activated = true;
            }
            
        } 
    }

    public void Flip()
    {
        
//        if (GrabThrowBehavior.GrabbedObject != null)
//            return;
        
        Debug.Log("Flip");
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        
        foreach (var behavior in _behaviors)
        {
            if (behavior.Activated)
                behavior.OnFlip();
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        modeAlertAnim.SetTrigger("modeSwapped");

        if (collision.gameObject.name == "Trigger Zone C")
        {
            Debug.Log("Successfully exited");
            exitAlertAnim.SetTrigger("modeSwapped");
        }
    }

}