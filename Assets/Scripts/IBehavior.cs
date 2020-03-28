using UnityEngine;

namespace Behaviors
{
    public interface IBehavior
    {
        void OnActionPress();
        void OnActionRelease();
//        void OnActionHold();
        BehaviorManager BehaviorManager { get; set; }
        MonoBehaviour Script { get; set; }
        bool Activated { get; set; }

    }
}