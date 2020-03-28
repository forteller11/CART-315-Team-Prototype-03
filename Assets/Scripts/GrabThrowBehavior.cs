using System;
using UnityEngine;

namespace Behaviors
{
    public class GrabThrowBehavior : MonoBehaviour, IBehavior
    {
        public BehaviorManager BehaviorManager { get; set; }
        public MonoBehaviour Script { get; set; }
        
        private Transform _grabbedItem;
        [SerializeField] private float _releaseForce;
        [SerializeField] private HingeJoint2D _grabHingeJoint2D;
        
        [SerializeField] private Vector2 CollisionOffset;
        [SerializeField] private float CollisionSize = 1;
        [SerializeField] private CollisionFlags GrabbableObjects;

        
        private void OnEnable()
        {
            _grabbedItem = null;
        }
        
        private void OnDisable()
        {
            _grabbedItem = null;
            if (_grabHingeJoint2D != null)
                _grabHingeJoint2D.connectedBody = null;
        }

        public void PerformAction()
        {
            //TODO check for collisions with grabbable objects
            //TODO add joint, then connect it to self
        }

        
    }
}