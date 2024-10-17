using System.Collections;
using System.Collections.Generic;
using CBPXL.InteractSystem;
using UnityEngine;

namespace CBPXL.InspectionSystem
{
    public class Inspector : MonoBehaviour
    {
        #region FIELDS
        private bool _inspecting = false;
        private bool _insideArea = false;
        #endregion

        #region PROPERTIES
        public bool Inspecting { get { return _inspecting; } set { _inspecting = value; } }
        public bool InsideArea { get { return _insideArea; } }
        #endregion

        #region REFERENCES
        private List<Collider> _colliderObjects = new List<Collider>();
        private List<Collider> _cleanableColliders = new List<Collider>();
        #endregion

        #region DEFAULT METHODS
        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IInspectable>() != null)
            {
                _insideArea = true;
                _colliderObjects.Add(other);
            }
        }
        public void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<IInspectable>() != null)
            {
                _insideArea = false;
                _cleanableColliders.Add(other);
                StartCoroutine(CleanInteractableArray());
            }
        }
        #endregion

        #region CUSTOM METHODS
        public void Inspect()
        {
            if (_insideArea && _inspecting)
            {
                foreach (Collider collider in _colliderObjects)
                {
                    IInspectable inspectable;
                    collider.gameObject.TryGetComponent<IInspectable>(out inspectable);
                    if (inspectable != null)
                    {
                        inspectable.OnInspect();
                        _inspecting = false;
                        return;
                    }
                }
            }
        }

        public void Highlight(Collider other, bool toggleOn)
        {
            HighlightObject highlightable;
            other.gameObject.TryGetComponent<HighlightObject>(out highlightable);
            if (highlightable != null)
            {
                highlightable.HighlightInteractable(toggleOn);
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
