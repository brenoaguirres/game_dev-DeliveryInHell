using UnityEngine;

[CreateAssetMenu(fileName = "ControllableCharacterDataInput", menuName = "Scriptable Objects/ControllableCharacterDataInput")]
public class ControllableCharacterDataInput : ScriptableObject
{
    #region FIELDS
    private bool _horizontalInput = false;
    private bool _runInput = false;
    private bool _jumpInput = false;
    #endregion
    
    #region PROPERTIES
    public bool HorizontalInput
    {
        get { return _horizontalInput; }
        set { _horizontalInput = value; }
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
    #endregion
}
