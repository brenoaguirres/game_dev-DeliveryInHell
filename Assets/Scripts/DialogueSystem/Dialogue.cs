using System.Collections.Generic;
using CBPXL.DialogueSystem;
using CBPXL.InteractSystem;
using UnityEngine;

public class Dialogue : MonoBehaviour, IInteractable
{
    #region FIELDS
    [Header("Text")]
    [SerializeField] private string[] _lines;

    [Header("Highlightable Meshes")]
    [SerializeField] private List<MeshRenderer> _highlightables = new List<MeshRenderer>();
    [SerializeField] private Material _highlightMaterial;
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

    public void HighlightInteractable(bool toggleOn)
    {
        if (toggleOn)
        {
            if (_highlightables == null)
            {
                Debug.LogWarning("No highlightable meshes assigned on interactable object: " + gameObject.name);
                return;
            }

            foreach (MeshRenderer mesh in _highlightables)
            {
                Material[] matArray = new Material[mesh.materials.Length + 1];
                for (int i = 0; i < mesh.materials.Length; i++)
                {
                    matArray[i] = mesh.materials[i];
                }
                matArray[mesh.materials.Length] = _highlightMaterial;
                mesh.materials = matArray;
            }
        }
        else
        {
            if (_highlightables == null)
            {
                Debug.LogWarning("No highlightable meshes assigned on interactable object: " + gameObject.name);
                return;
            }

            foreach (MeshRenderer mesh in _highlightables)
            {
                Material[] matArray = new Material[mesh.materials.Length - 1];
                for (int i = 0; i < mesh.materials.Length; i++)
                {
                    if (mesh.materials[i].name + " (Instance)" != _highlightMaterial.name)
                    {
                        matArray[i] = mesh.materials[i];
                    }
                }
                mesh.materials = matArray;
            }
        }
    }
    #endregion
}
