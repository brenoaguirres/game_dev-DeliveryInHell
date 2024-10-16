using Unity.Burst.Intrinsics;
using UnityEngine;

[CreateAssetMenu(fileName = "ControllableCharacterDataInput", menuName = "Scriptable Objects/ControllableCharacterDataInput")]
public class ControllableCharacterDataInput : ScriptableObject
{
    #region FIELDS
    [SerializeField] private float _horizontalInput = 0f;
    [SerializeField] private float _verticalInput = 0f;
    [SerializeField] private bool _runInput = false;
    [SerializeField] private bool _jumpInput = false;
    [SerializeField] private bool _aimInput = false;
    [SerializeField] private bool _shootInput = false;
    [SerializeField] private bool _interactInput = false;
    [SerializeField] private float _aimPosInput = 0f;
    [SerializeField] private bool _crouchInput = false;
    #endregion
    
    #region PROPERTIES
    public float HorizontalInput
    {
        get { return _horizontalInput; }
        set { _horizontalInput = value; }
    }
    public float VerticalInput
    {
        get { return _verticalInput; }
        set { _verticalInput = value; }
    }
    public bool RunInput
    {
        get { return _runInput; }
        set { _runInput = value; }
    }
    public bool JumpInput
    {
        get { return _jumpInput; }
        set { _jumpInput = value; }
    }
    public bool AimInput
    {
        get { return _aimInput; }
        set { _aimInput = value; }
    }
    public bool ShootInput
    {
        get { return _shootInput; }
        set { _shootInput = value; }
    }
    public bool InteractInput
    {
        get { return _interactInput; }
        set { _interactInput = value; }
    }
    public float AimPosInput
    {
        get { return _aimPosInput; }
        set { _aimPosInput = value; }
    }

    public bool CrouchInput
    {
        get { return _crouchInput; }
        set { _crouchInput = value; }
    }
    #endregion
}
