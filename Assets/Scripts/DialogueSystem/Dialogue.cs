using System.Collections.Generic;
using CBPXL.InteractSystem;
using UnityEngine;

namespace CBPXL.DialogueSystem
{
    public class Dialogue : MonoBehaviour, IInteractable
    {
        #region FIELDS
        [Header("Text")]
        [SerializeField] private string[] _lines;
        #endregion

        #region REFERENCES
        [Header("Dialogue Box")]
        [SerializeField] private DialogueBox _dBox;
        #endregion

        #region CUSTOM METHODS
        public void OnInteract()
        {
            _dBox.ChangeText(_lines);
            _dBox.gameObject.SetActive(true);
        }
        #endregion
    }
}