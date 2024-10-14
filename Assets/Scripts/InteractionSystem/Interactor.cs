using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace CBPXL.InteractSystem
{
    public class Interactor : MonoBehaviour
    {
        #region FIELDS
        private bool _interacting = false;
        private bool _insideArea = false;
        #endregion

        #region PROPERTIES
        public bool Interacting {  get { return _interacting; } set { _interacting = value; } }
        public bool InsideArea { get { return _insideArea; }}
        #endregion

        #region REFERENCES
        private List<Collider> _colliderObjects = new List<Collider>();
        private List<Collider> _cleanableColliders = new List<Collider>();
        #endregion

        // if this do not works properly, try Physics.OverlapBox instead
        #region DEFAULT METHODS
        public void OnTriggerEnter(Collider other)
        {
            _insideArea = true;
            _colliderObjects.Add(other);
        }
        public void OnTriggerExit(Collider other)
        {
            _insideArea = false;
            _cleanableColliders.Add(other);
            StartCoroutine(CleanInteractableArray());
        }
        #endregion

        #region CUSTOM METHODS
        public void Interact()
        {
            if (_insideArea && _interacting)
            {
                foreach (Collider collider in _colliderObjects)
                {
                    IInteractable interactable;
                    collider.gameObject.TryGetComponent<IInteractable>(out interactable);
                    if (interactable != null)
                    {
                        interactable.OnInteract();
                        _interacting = false;
                        return;
                    }
                }
            }
        }

        private IEnumerator CleanInteractableArray()
        {
            if (_cleanableColliders.Count == 0) yield return null;

            yield return new WaitForEndOfFrame();
            foreach (Collider rmCol in _cleanableColliders)
            {
                if (_colliderObjects.Contains(rmCol))
                    _colliderObjects.Remove(rmCol);
            }

            _cleanableColliders.Clear();
        }
        #endregion
    }
}
