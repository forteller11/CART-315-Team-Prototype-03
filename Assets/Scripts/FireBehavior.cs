﻿using System.Collections;
using System.Collections.Generic;
using Behaviors;
using UnityEngine;

public class FireBehavior : MonoBehaviour, IBehavior
{
    public BehaviorManager BehaviorManager { get; set; }
    public MonoBehaviour Script { get; set; }
    
    private GameObject player;
    BehaviorManager _behaviorManagerScript;

    Animator fireAnim;

    // Start is called before the first frame update
    void Start()
    {
        fireAnim = GetComponent<Animator>();
        player = GameObject.Find("PlayerSprite");
        _behaviorManagerScript = player.GetComponent<BehaviorManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (_behaviorManagerScript.AbilityMode)
        {
            case BehaviorManager.AbilityModeEnum.Jump:
                fireAnim.SetInteger("modeIndex", 0);
                break;
            case BehaviorManager.AbilityModeEnum.Fire:
                fireAnim.SetInteger("modeIndex", 1);
                break;
            case BehaviorManager.AbilityModeEnum.GrabThrow:
                fireAnim.SetInteger("modeIndex", 2);
                break;
        }
    }

    public void PerformAction()
    {
        throw new System.NotImplementedException();
    }
}