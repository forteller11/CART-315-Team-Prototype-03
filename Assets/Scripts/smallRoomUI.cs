using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class smallRoomUI : MonoBehaviour
{
    private GameObject player;
    BehaviorManager _behaviorManagerScript;

    private Text modeAlert;
    Animator modeAlertAnim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerSprite");
        _behaviorManagerScript = player.GetComponent<BehaviorManager>();

        modeAlert = GameObject.Find("Mode Alert").GetComponent<Text>();
        modeAlertAnim = GameObject.Find("Mode Alert").GetComponent<Animator>();
        modeAlert.text = "test :y";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        modeAlert.text = "Mode: ";
        bool multipleModesActive = false;
        
        if (_behaviorManagerScript.MoveBehavior.enabled)
        {
            modeAlert.text += " Walk";
            if (multipleModesActive)
                modeAlert.text += " &";
            multipleModesActive = true;
        }
        if (_behaviorManagerScript.JumpBehavior.enabled)
        {
            modeAlert.text += " Jump";
            if (multipleModesActive)
                modeAlert.text += " &";
            multipleModesActive = true;
        }
        if (_behaviorManagerScript.FireBehavior.enabled)
        {
            modeAlert.text += " Fire";
            if (multipleModesActive)
                modeAlert.text += " &";
            multipleModesActive = true;
        }
        if (_behaviorManagerScript.GrabThrowBehavior.enabled)
        {
            modeAlert.text += " Grab/Throw";
            if (multipleModesActive)
                modeAlert.text += " &";
            multipleModesActive = true;
        }
        
    }
}
