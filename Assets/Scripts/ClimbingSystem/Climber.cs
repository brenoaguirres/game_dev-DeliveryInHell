using CBPXL.InspectionSystem;
using CBPXL.InteractSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CBPXL.ClimbingSystem
{
    public class Climber : MonoBehaviour
    {
        #region FIELDS
        private bool _touchingClimbable = false;
        [SerializeField] private Transform _climberPosition;
        #endregion

        #region PROPERTIES
        public bool TouchingClimbable 
        { 
            get 
            { 
                return _touchingClimbable; 
            } 
            private set 
            { 
                _touchingClimbable = value; 

                if (_touchingClimbable)
                {
                    OnTouchClimbable();
                }
            } 
        }
        
        public Transform ClimberPosition { get { return _climberPosition; } set { _climberPosition = value; } }
        public List<Collider> Climbables { get { return _climbables; } }
        public GameObject PlayerGameObject { get { return _playerGameObject; } }
        #endregion

        #region REFERENCES
        private List<Collider> _climbables = new List<Collider>();
        private List<Collider> _cleanableColliders = new List<Collider>();
        [SerializeField] private GameObject _playerGameObject;
        
        #endregion

        #region EVENTS
        public Action<bool> onTouchClimbable;
        #endregion

        #region DEFAULT METHODS
        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Climbable>() != null)
            {
                _climbables.Add(other);
                if (_climbables.Count > 0)
                {
                    TouchingClimbable = true;
                }
            }
        }
        public void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Climbable>() != null)
            {
                _cleanableColliders.Add(other);
                StartCoroutine(CleanInteractableArray());
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_climberPosition.position, 0.6f);
        }
        #endregion

        #region CUSTOM METHODS
        public void OnTouchClimbable()
        {
            onTouchClimbable?.Invoke(true);
        }

        private IEnumerator CleanInteractableArray()
        {
            if (_cleanableColliders.Count == 0) yield return null;

            yield return new WaitForEndOfFrame();
            foreach (Collider rmCol in _cleanableColliders)
            {
                if (_climbables.Contains(rmCol))
                    _climbables.Remove(rmCol);
            }

            _cleanableColliders.Clear();
            
            if (_climbables.Count == 0)
            {
                _touchingClimbable = false;
                onTouchClimbable?.Invoke(false);
            }
        }
        #endregion
    }
}