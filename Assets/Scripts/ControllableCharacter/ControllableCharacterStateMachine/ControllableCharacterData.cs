using CBPXL.ControllableCharacter;
using CBPXL.InteractSystem;
using CBPXL.WeaponSystem;
using UnityEngine;

[CreateAssetMenu(fileName = "ControllableCharacterData", menuName = "Scriptable Objects/ControllableCharacterData")]
public class ControllableCharacterData : ScriptableObject
{
    #region FIELDS
    [Header("Movement")]
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _runSpeed = 10f;
    private bool _isRunning = false;
    [Tooltip("How many seconds does the move input should take to lerp to 0 after key up?")]
    [SerializeField] private float _skidTime = 0;

    [Space(2)]
    [Header("Jump")]
    [SerializeField] private float _maxJumpForce = 5f;
    [Tooltip("How many seconds does the jump input should take to lerp to max after key down?")]
    [SerializeField] private float _maxJumpTime = 1f;
    private float _currentJumpForce = 0f;
    private bool _canJump = false;
    private bool _isGrounded = true;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _maxGroundCheckDist = 1f;
    [Tooltip("The position in which the character's feet is located.")]
    [SerializeField] private Transform _jumpBasePosition;

    [Space(2)]
    [Header("Aim")]
    [SerializeField] private float _lowerAimMouseThreshold = 350f;
    [SerializeField] private float _upperAimMouseThreshold = 500f;
    
    [Space(2)]
    [Header("Shoot")]
    [SerializeField] private WeaponData _rangedWeapon;
    [SerializeField] private WeaponData _meleeWeapon;
    [SerializeField] private WeaponData _throwableWeapon;
    [SerializeField] private bool _canShoot = true;
    [SerializeField] private float _fireRateTimer = 0f;
    [SerializeField] private float _reloadTimer = 0f;
    #endregion

    #region PROPERTIES
    // walk/run
    public float WalkSpeed { get { return _walkSpeed; } set { _walkSpeed = value; } }
    public float RunSpeed { get { return _runSpeed;  } set { _runSpeed = value; } }
    public bool IsRunning { get { return  _isRunning; } set { _isRunning = value; } }
    public float SkidTime { get { return _skidTime; } set { _skidTime = value; } }
    // jump
    public float MaxJumpForce { get { return _maxJumpForce; } set { _maxJumpForce = value; } }
    public float MaxJumpTime { get { return _maxJumpTime; } set { _maxJumpTime = value; } }
    public float CurrentJumpForce { get { return _currentJumpForce; } set { _currentJumpForce = value; } }
    public bool CanJump { get { return _canJump; } set { _canJump = value; } }
    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }
    public LayerMask GroundLayer { get { return _groundLayer; } set { _groundLayer = value; } }
    public float MaxGroundCheckDist { get { return _maxGroundCheckDist; } set { _maxGroundCheckDist = value; } }
    public Transform JumpBasePosition { get { return _jumpBasePosition; } set { _jumpBasePosition = value; } }
    // aim
    public float LowerAimMouseThreshold { get { return _lowerAimMouseThreshold; } set { _lowerAimMouseThreshold = value; } }
    public float UpperAimMouseThreshold { get { return _upperAimMouseThreshold; } set { _upperAimMouseThreshold = value; } }
    // refs
    public Rigidbody Physics { get { return _physics; } set { _physics = value; } }
    public Animator Animator { get { return _animator; } set { _animator = value; } }
    public AttackPlayer Attack { get { return _attack; } set { _attack = value; } }
    public Interactor Interactor { get { return _interactor; } set { _interactor = value; } }
    #endregion

    #region REFERENCES
    private Rigidbody _physics;
    private Animator _animator;

    private AttackPlayer _attack;
    private Interactor _interactor;
    #endregion
}
