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
        private bool _grounded;

        public float JumpForce = 1400f;

//        public BoxCollider2D _groundCollider2D;
//        public Vector2 
//
//        private void Awake()
//        {
//            _groundCollider2D = this.gameObject.AddComponent<BoxCollider2D>();
//            _groundCollider2D.size = sizeO
//        }

        private void Update()
        {
            List<Collider2D> overlappingColliders = new List<Collider2D>();
            if (Physics2D.GetContacts(BehaviorManager.Rb, overlappingColliders) > 0)
            {
                for (int i = 0; i < overlappingColliders.Count; i++)
                {
                    if (overlappingColliders[i].gameObject.tag == "Ground")
                    {
                        _grounded = true;
                    }
                }

            }
            else
            {
                _grounded = false;
            }
        }

        private void OnDrawGizmosSelected()
        {
//            Gizmos.DrawWireCube(BehaviorManager.Rb.position + _groundCollider2D.offset, _groundCollider2D.size);
        }
        
        
        public void OnActionPress()
        {
            if (_grounded == false)
                return;
            
            BehaviorManager.Rb.AddForce(new Vector2(0, JumpForce));
        }
        
        public void OnActionRelease()
        {
            if (_grounded == true)
                return;
            if (BehaviorManager.Rb.velocity.y > 0)
                BehaviorManager.Rb.velocity *= new Vector2(1, .6f);
        }

        
    }
}