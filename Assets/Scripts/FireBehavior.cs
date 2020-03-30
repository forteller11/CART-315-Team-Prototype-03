using System.Collections;
using System.Collections.Generic;
using Behaviors;
using UnityEngine;

public class FireBehavior : MonoBehaviour, IBehavior
{
    public void OnActionRelease()
    {
        throw new System.NotImplementedException();
    }

    public void OnFlip()
    {
        throw new System.NotImplementedException();
    }

    public BehaviorManager BehaviorManager { get; set; }
    public MonoBehaviour Script { get; set; }
    public bool Activated { get; set; }

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

//        if (BehaviorManager.GrabThrowBehavior.GrabbedObject != null)
//        {
//            fireAnim.SetInteger("modeIndex", 0);
//            return;
//        }
//        
//        if (BehaviorManager.GrabThrowBehavior.GrabbedObject != null)
//        {
//            fireAnim.SetInteger("modeIndex", 0);
//            return;
//        }
//
//        case BehaviorManager.AbilityModeEnum.Fire:
//                fireAnim.SetInteger("modeIndex", 1);
//                break;
//            case BehaviorManager.AbilityModeEnum.GrabThrow:
//                fireAnim.SetInteger("modeIndex", 2);
//                break;
//        }
    }

    public void OnActionPress()
    {
        throw new System.NotImplementedException();
    }
}
