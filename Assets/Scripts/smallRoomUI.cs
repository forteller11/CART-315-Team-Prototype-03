using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class smallRoomUI : MonoBehaviour
{
    private GameObject player;
    playerMovement playerMovementScript;

    private Text modeAlert;
    Animator modeAlertAnim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerSprite");
        playerMovementScript = player.GetComponent<playerMovement>();

        modeAlert = GameObject.Find("Mode Alert").GetComponent<Text>();
        modeAlertAnim = GameObject.Find("Mode Alert").GetComponent<Animator>();
        modeAlert.text = "test :y";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (playerMovementScript.abilityIndex)
        {
            case 0:
                modeAlert.text = "Mode 1";
                break;
            case 1:
                modeAlert.text = "Mode 2";
                break;
            case 2:
                modeAlert.text = "Mode 3";
                break;
        }
    }
}
