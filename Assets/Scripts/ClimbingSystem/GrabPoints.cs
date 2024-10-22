using System.Collections.Generic;
using UnityEngine;

public class GrabPoints : MonoBehaviour
{
    #region FIELDS
    [Header("Points")]
    [SerializeField] List<Transform> _grabPointList;
    [SerializeField] List<Transform> _upperPointList;

    [Space(2)]
    [Header("Drawing")]
    private float _gizmoSize = 0.4f;
    #endregion

    #region PROPERTIES
    public List<Transform> GrabPointList {  get { return _grabPointList; } }
    public List<Transform> UpperPointList { get { return _upperPointList; } }
    #endregion

    #region GIZMOS
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (Transform t in _grabPointList)
        {
            Gizmos.DrawWireSphere(t.position, _gizmoSize);
        }

        Gizmos.color = Color.blue;
        foreach (Transform t in _upperPointList)
        {
            Gizmos.DrawWireSphere(t.position, _gizmoSize);
        }
    }
    #endregion
}
