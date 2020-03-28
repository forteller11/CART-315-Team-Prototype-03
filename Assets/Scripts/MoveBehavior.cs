using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Behaviors
{
    public class MoveBehavior: MonoBehaviour, IBehavior
    {
        public BehaviorManager BehaviorManager { get; set; }
        public MonoBehaviour Script { get; set; }
        
        public float MovementMultiplier = 10f;
        
        public void PerformAction()
        {
            throw new System.NotImplementedException();
        }

        public void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 horizontalForce = new Vector2(horizontalInput * MovementMultiplier, 0f);
            
            BehaviorManager.Rb.AddForce(horizontalForce);
            

            if (Math.Abs(horizontalInput) > 0.01f)
            {
                if (BehaviorManager.Rb.velocity.x > 0)
                {
                    BehaviorManager.Animator.SetBool("isWalkingAhead", true);
                    BehaviorManager.Animator.SetBool("isWalkingBack", false);
                }
                else
                {
                    BehaviorManager.Animator.SetBool("isWalkingAhead", false);
                    BehaviorManager.Animator.SetBool("isWalkingBack", true);
                }
                
            }
        }
    }
}