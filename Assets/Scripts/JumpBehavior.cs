using UnityEngine;

namespace Behaviors
{
    public class JumpBehavior : MonoBehaviour, IBehavior
    {
        public BehaviorManager BehaviorManager { get; set; }
        public MonoBehaviour Script { get; set; }
        
        public void PerformAction()
        {
            throw new System.NotImplementedException();
        }

        
    }
}