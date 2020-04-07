using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructionUI : MonoBehaviour
{
    private Text instructionAlert;
    Animator instructionAlertAnim;
    private Text cubeAlert;
    Animator cubeAlertAnim;
    Animator cubeArrowAnim;

    private GameObject player;
    BehaviorManager _behaviorManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        instructionAlert = GameObject.Find("Instruction Alert").GetComponent<Text>();
        instructionAlertAnim = GameObject.Find("Instruction Alert").GetComponent<Animator>();
        cubeAlert = GameObject.Find("Cube Alert").GetComponent<Text>();
        cubeAlertAnim = GameObject.Find("Cube Alert").GetComponent<Animator>();
        cubeArrowAnim = GameObject.Find("Arrow").GetComponent<Animator>();

        player = GameObject.Find("PlayerSprite");
        _behaviorManagerScript = player.GetComponent<BehaviorManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_behaviorManagerScript.actionFlag2Activated)
        {
            instructionAlert.text = "There's gotta be an exit somewhere...";
            cubeAlert.text = "You can grab and hurl these";
            instructionAlertAnim.SetInteger("index", 2);
            cubeAlertAnim.SetBool("ready", true);
            cubeArrowAnim.SetBool("ready", true);
        } else if (_behaviorManagerScript.actionFlag1Activated)
        {
            instructionAlert.text = "The space bar is the action button.";
            instructionAlertAnim.SetInteger("index", 1);
        }
        else
        {
            instructionAlert.text = "The arrow keys are the movement buttons.";
            instructionAlertAnim.SetInteger("index", 0);
        }
    }
}
