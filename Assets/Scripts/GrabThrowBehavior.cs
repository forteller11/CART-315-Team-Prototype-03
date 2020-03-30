using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Behaviors
{
    public class GrabThrowBehavior : MonoBehaviour, IBehavior
    {

        public BehaviorManager BehaviorManager { get; set; }
        public MonoBehaviour Script { get; set; }
        public bool Activated { get; set; }

        [SerializeField] private GameObject _grabFocus;
        [SerializeField] private GameObject _grabbedObject;
        [SerializeField] private float _releaseForceMultiplier = 4;
        [SerializeField] private FixedJoint2D _grabHingeJoint2D;
        
        [SerializeField] private float LiftHeight = 0.2f;

        private void Update()
        {
            
            if (_grabHingeJoint2D != null)
                _grabHingeJoint2D.autoConfigureConnectedAnchor = false;

            if (Activated == false || _grabbedObject != null)
            {
                _grabFocus = null;
                return;
            }
            
            
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
                        return;
                    }
                }

            }
            _grabFocus = null;
        }



        public void OnActionPress()
        {
            if (_grabFocus == null)
                return;
            
            Debug.Log("Grab");
            _grabbedObject = _grabFocus;
            _grabHingeJoint2D = _grabbedObject.GetComponent<FixedJoint2D>();
            if (_grabHingeJoint2D == null)
                _grabHingeJoint2D = _grabbedObject.AddComponent<FixedJoint2D>();
            _grabHingeJoint2D.enabled = true;
            _grabHingeJoint2D.connectedBody = BehaviorManager.Rb;
            _grabHingeJoint2D.autoConfigureConnectedAnchor = true;
        }

        public void OnActionRelease()
        {
            if (_grabbedObject == null)
                return;
            
            Debug.Log("Grab release");
            _grabHingeJoint2D.connectedBody = null;
            _grabHingeJoint2D.enabled = false;
            _grabHingeJoint2D = null;
            _grabbedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                BehaviorManager.Rb.velocity.x * _releaseForceMultiplier,
                BehaviorManager.Rb.velocity.y
            );
            _grabbedObject = null;
        }
        
        public void OnFlip()
        {
            if (_grabbedObject == null)
                return;

            //flip held object
            //TODO, if object now bangs into wall, reflip object to prevent flip

            var position = transform.position;

            Debug.Log($"Pre {transform.localPosition}");

            _grabHingeJoint2D.connectedAnchor = new Vector2(-_grabHingeJoint2D.connectedAnchor.x, _grabHingeJoint2D.connectedAnchor.y);



            //_grabHingeJoint2D.autoConfigureConnectedAnchor = true;

        }
        
        
    }
}