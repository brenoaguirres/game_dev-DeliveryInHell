using System;
using System.Collections;
using System.Runtime.CompilerServices;
using CBPXL.InspectionSystem;
using UnityEngine;
using UnityEngine.Events;

namespace CBPXL.AreaLoader
{
    public class AreaLoader : MonoBehaviour, IInspectable
    {
        #region FIELDS
        [Header("Settings")]
        [SerializeField] private bool _lockedEntrance = false;

        [Header("Areas")]
        [SerializeField] private GameObject _currentArea;
        [SerializeField] private GameObject _nextArea;
        #endregion

        #region PROPERTIES
        public bool LockedEntrance { get { return _lockedEntrance; } set { _lockedEntrance = value; } }
        #endregion

        #region EVENTS
        [SerializeField] public UnityEvent onDoorLocked;
        #endregion

        #region CUSTOM METHODS
        private IEnumerator LoadArea()
        {
            Debug.Log("Loading Area");
            yield return new WaitForSeconds(0.2f);
            _nextArea.SetActive(true);
            Debug.Log("Area Loaded");
            _currentArea.SetActive(false);
        }
        #endregion

        #region IInspectable METHODS
        public void OnInspect()
        {
            if (!LockedEntrance)
            {
                StartCoroutine(LoadArea());
            }
            else
            {
                onDoorLocked?.Invoke();
            }
        }
        #endregion
    }
}