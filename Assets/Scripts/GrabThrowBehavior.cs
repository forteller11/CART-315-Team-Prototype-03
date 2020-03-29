using System;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviors
{
    public class GrabThrowBehavior : MonoBehaviour, IBehavior
    {
        public BehaviorManager BehaviorManager { get; set; }
        public MonoBehaviour Script { get; set; }
        public bool Activated { get; set; }

        private GameObject _grabFocus;
        private GameObject _grabbedObject;
        [SerializeField] private float _releaseForceMultiplier = 4;
        [SerializeField] private HingeJoint2D _grabHingeJoint2D;
        
        [SerializeField] private Vector2 CollisionOffset;
        [SerializeField] private float CollisionSize = 1;

        private void Update()
        {
            if (Activated == false)
                return;
            
            BehaviorManager.JumpBehavior.Activated = true;
            List<Collider2D> overlappingColliders = new List<Collider2D>();
            if (Physics2D.GetContacts(BehaviorManager.Rb, overlappingColliders) > 0)
            {
                for (int i = 0; i < overlappingColliders.Count; i++)
                {
                    if (overlappingColliders[i].gameObject.tag == "Grabbable")
                    {
                        Debug.Log("Ready to Grab");
                        _grabFocus = overlappingColliders[i].gameObject;
                        BehaviorManager.JumpBehavior.Activated = false;
                    }
                }

            }
            else
            {
                _grabFocus = null;
            }
            
        }
        
        
        public void OnActionPress()
        {
            if (_grabFocus == null)
                return;
            
            Debug.Log("Grab");
            _grabbedObject = _grabFocus;
            _grabHingeJoint2D = _grabbedObject.GetComponent<HingeJoint2D>();
            if (_grabHingeJoint2D == null)
                _grabHingeJoint2D = _grabbedObject.AddComponent<HingeJoint2D>();
            _grabHingeJoint2D.connectedBody = BehaviorManager.Rb;
            _grabHingeJoint2D.autoConfigureConnectedAnchor = false;
        }

        public void OnActionRelease()
        {
            if (_grabbedObject == null)
                return;
            
            Debug.Log("Grab release");
            Destroy(_grabHingeJoint2D);
            _grabHingeJoint2D = null;
           
            _grabbedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                BehaviorManager.Rb.velocity.x * _releaseForceMultiplier,
                BehaviorManager.Rb.velocity.y
            );
            _grabbedObject = null;
        }
    }
}