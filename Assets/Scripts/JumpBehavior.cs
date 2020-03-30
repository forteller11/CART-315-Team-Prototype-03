using System;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviors
{
    public class JumpBehavior : MonoBehaviour, IBehavior
    {

        public BehaviorManager BehaviorManager { get; set; }
        public MonoBehaviour Script { get; set; }
        public bool Activated { get; set; }
        public bool Grounded { private set; get; }

        public float JumpForce = 500f;

        private void Update()
        {
            List<Collider2D> overlappingColliders = new List<Collider2D>();
            if (Physics2D.GetContacts(BehaviorManager.Rb, overlappingColliders) > 0)
            {
                for (int i = 0; i < overlappingColliders.Count; i++)
                {
                    if (overlappingColliders[i].gameObject.tag == "Ground")
                    {
                        Grounded = true;
                    }
                }

            }
            else
            {
                Grounded = false;
            }
        }

        private void OnDrawGizmosSelected()
        {
//            Gizmos.DrawWireCube(BehaviorManager.Rb.position + _groundCollider2D.offset, _groundCollider2D.size);
        }
        
        
        public void OnActionPress()
        {
            if (Grounded == false)
                return;
            
            BehaviorManager.Rb.AddForce(new Vector2(0, JumpForce));
            Grounded = false;
        }
        
        public void OnActionRelease()
        {
            if (Grounded)
                return;
            
            if (BehaviorManager.Rb.velocity.y > 0)
                BehaviorManager.Rb.velocity *= new Vector2(1, .6f);
        }
        
        public void OnFlip() { }

        
    }
}