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

        public float JumpForce = 200f;

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
                Debug.Log("overlapped");
                for (int i = 0; i < overlappingColliders.Count; i++)
                {
                    if (overlappingColliders[i].gameObject.tag == "Ground")
                    {
                        Debug.Log("grounded");
                        Activated = true;
                    }
                }
                Activated = true;
                
            }
            else
            {
                Debug.Log("exit grounded");
                Activated = false;
            }
        }

        private void OnDrawGizmosSelected()
        {
//            Gizmos.DrawWireCube(BehaviorManager.Rb.position + _groundCollider2D.offset, _groundCollider2D.size);
        }
        
        
        public void PerformAction()
        {
            BehaviorManager.Rb.AddForce(new Vector2(0, JumpForce));
            Debug.Log("Jump");
        }

        
    }
}