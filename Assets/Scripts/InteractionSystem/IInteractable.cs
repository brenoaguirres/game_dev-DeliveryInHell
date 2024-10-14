using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CBPXL.InteractSystem
{
    public interface IInteractable
    {
        public void HighlightInteractable(bool toggleOn);
        public void OnInteract();
    }
}