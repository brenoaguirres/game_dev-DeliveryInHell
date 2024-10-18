using System.Collections.Generic;
using UnityEngine;

namespace CBPXL.ClimbingSystem
{
    public class Climbable : MonoBehaviour
    {
        #region FIELDS
        [SerializeField] private List<Transform> _grabPoints;
        [SerializeField] private ClimbType _type = ClimbType.LEDGE;
        #endregion

        #region PROPERTIES
        public List<Transform> GrabPoints { get { return _grabPoints; } }
        public ClimbType Type { get { return _type; } }
        #endregion

        #region CLIMBTYPE_ENUM
        public enum ClimbType
        {
            LEDGE,
            LADDER,
            STAIRS,
            ELEVATOR,
            ROPE
        }
        #endregion

        #region DEFAULT METHODS
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            foreach (Transform t in _grabPoints)
                Gizmos.DrawWireSphere(t.position, 1f);
        }
        #endregion
    }
}
