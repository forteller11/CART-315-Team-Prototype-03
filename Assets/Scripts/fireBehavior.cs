using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBehavior : MonoBehaviour
{
    private GameObject player;
    playerMovement playerMovementScript;

    Animator fireAnim;

    // Start is called before the first frame update
    void Start()
    {
        fireAnim = GetComponent<Animator>();
        player = GameObject.Find("PlayerSprite");
        playerMovementScript = player.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (playerMovementScript.abilityIndex)
        {
            case 0:
                fireAnim.SetInteger("modeIndex", 0);
                break;
            case 1:
                fireAnim.SetInteger("modeIndex", 1);
                break;
            case 2:
                fireAnim.SetInteger("modeIndex", 2);
                break;
        }
    }
}
