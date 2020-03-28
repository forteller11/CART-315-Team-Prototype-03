using UnityEngine;

namespace Behaviors
{
    public interface IBehavior
    {
        void PerformAction();
        BehaviorManager BehaviorManager { get; set; }
        MonoBehaviour Script { get; set; }

    }
}