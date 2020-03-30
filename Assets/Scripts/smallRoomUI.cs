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
        List<string> modesActive = new List<string>();
        bool multipleModesActive = false;
        
        if (_behaviorManagerScript.MoveBehavior.enabled)
        {
            modesActive.Add(" Walk");
            if (multipleModesActive)
                modeAlert.text += " &";
            multipleModesActive = true;
        }
        if (_behaviorManagerScript.JumpBehavior.Grounded && _behaviorManagerScript.JumpBehavior.Activated)
        {
            modesActive.Add(" Jump");
            if (multipleModesActive)
                modeAlert.text += " &";
            multipleModesActive = true;
        }
        if (_behaviorManagerScript.FireBehavior.enabled)
        {
            modesActive.Add(" Fire");
            if (multipleModesActive)
                modeAlert.text += " &";
            multipleModesActive = true;
        }
        if (_behaviorManagerScript.GrabThrowBehavior.GrabbedObject != null)
        {
            modesActive.Add(" Grab/Throw");
            if (multipleModesActive)
                modeAlert.text += " &";
            multipleModesActive = true;
        }
        
        modeAlert.text = "Mode:";
        for (int i = 0; i < modesActive.Count; i++)
        {
            modeAlert.text += modesActive[i];
            if (i != modesActive.Count - 1)
                modeAlert.text += " &";
        }
        
        
    }
}
