using System.Collections.Generic;
using UnityEngine;

namespace CBPXL.InteractSystem
{
    public class HighlightObject : MonoBehaviour
    {
        #region FIELDS
        [Header("Highlightable Meshes")]
        [SerializeField] private List<MeshRenderer> _highlightables = new List<MeshRenderer>();
        [SerializeField] private Material _highlightMaterial;
        #endregion

        #region CUSTOM METHODS
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
                        if (mesh.materials[i].name != _highlightMaterial.name + " (Instance)")
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
}
