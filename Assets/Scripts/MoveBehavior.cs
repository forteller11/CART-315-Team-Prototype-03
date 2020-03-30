using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Behaviors
{
    public class MoveBehavior: MonoBehaviour, IBehavior
    {

        public BehaviorManager BehaviorManager { get; set; }
        public MonoBehaviour Script { get; set; }
        private Animator _animator;
        public bool Activated { get; set; }
        private int HorizontalSpeedAbsoluteId;
        private bool wasFacingRight = true;

        public float MovementMultiplier = 20f;
        public float MaxHorizontalVelocity = 3f;
        
        public void OnActionPress() { }
        public void OnActionRelease() { }
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            HorizontalSpeedAbsoluteId = Animator.StringToHash("HorizontalSpeedAbsolute");
        }

        public void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 horizontalForce = new Vector2(horizontalInput * MovementMultiplier, 0f);
            
            BehaviorManager.Rb.AddForce(horizontalForce);
            float clampedHorzVel = Mathf.Clamp(BehaviorManager.Rb.velocity.x, -MaxHorizontalVelocity, MaxHorizontalVelocity);
            BehaviorManager.Rb.velocity = new Vector2(clampedHorzVel, BehaviorManager.Rb.velocity.y);
            
            _animator.SetFloat(HorizontalSpeedAbsoluteId, Mathf.Abs(BehaviorManager.Rb.velocity.x));
            
            //check to see if should call flip method which will call OnFlip() on all activated behaviors
            if (horizontalInput < 0 && wasFacingRight == true)
            {
                BehaviorManager.Flip();
                wasFacingRight = false;
            }

            if (horizontalInput > 0 && wasFacingRight == false)
            {
                BehaviorManager.Flip();
                wasFacingRight = true;
            }
               

        }
        
        public void OnFlip() { }
    }
}