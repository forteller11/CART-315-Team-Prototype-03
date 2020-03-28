using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Behaviors
{
    public class MoveBehavior: MonoBehaviour, IBehavior
    {

        public BehaviorManager BehaviorManager { get; set; }
        public MonoBehaviour Script { get; set; }
        public bool Activated { get; set; }

        public float MovementMultiplier = 60f;
        public float MaxHorizontalVelocity = 3f;
        
        public void OnActionPress() { }
        public void OnActionRelease() { }
        

        public void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 horizontalForce = new Vector2(horizontalInput * MovementMultiplier, 0f);
            
            BehaviorManager.Rb.AddForce(horizontalForce);
            
            float clampedHorzVel = Mathf.Clamp(BehaviorManager.Rb.velocity.x, -MaxHorizontalVelocity, MaxHorizontalVelocity);
            BehaviorManager.Rb.velocity = new Vector2(clampedHorzVel, BehaviorManager.Rb.velocity.y);

            if (Math.Abs(horizontalInput) > 0.01f)
            {
                if (horizontalInput > 0)
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