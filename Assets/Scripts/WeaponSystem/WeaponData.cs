using UnityEngine;

namespace CBPXL.WeaponSystem
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        #region FIELDS
        [Header("ID")]
        [SerializeField] private string _weaponName = "Handgun";
        
        [Space(2)]
        [Header("Stats")]
        [SerializeField] private float _damageBase = 15f;
        [SerializeField][Range(0, 1)] private float _critRate = 0.1f;
        [SerializeField] private float _critMultiplier = 1.5f;
        [SerializeField] private float _fireRate = 0.8f;
        [SerializeField] private float _reloadSpeed = 1f;
        [SerializeField] private float _maxRange = 3f;
        [SerializeField] private int _maxChamberBullets = 8;
        [SerializeField] private int _maxStoredBullets = 40;
        [SerializeField] private int _currentChamberBullets = 0;
        [SerializeField] private int _currentStoredBullets = 0;
        
        [Space(2)]
        [Header("Type")]
        [SerializeField] private WeaponType _weaponType = WeaponType.RANGED;
        [SerializeField] private SubType _weaponSubType = SubType.LIGHT;
        [SerializeField] private ActionType _actionType = ActionType.SEMI_AUTO;
        
        [Space(2)]
        [Header("Visuals")]
        [SerializeField] private Mesh _weaponMesh;
        #endregion

        #region PROPERTIES
        // ID
        public string WeaponName { get { return _weaponName; } set { _weaponName = value; } }
        // Stats
        public float DamageBase { get { return _damageBase; } set { _damageBase = value; } }
        public float CritRate { get { return _critRate; } set { _critRate = value; } }
        public float CritMultiplier { get { return _critMultiplier; } set { _critMultiplier = value; } }
        public float FireRate { get { return _fireRate; } set { _fireRate = value; } }
        public float ReloadSpeed { get { return _reloadSpeed; } set { _reloadSpeed = value; } }
        public float MaxRange { get { return _maxRange; } set { _maxRange = value; } }
        public int MaxChamberBullets { get { return _maxChamberBullets; } set { _maxChamberBullets = value; } }
        public int MaxStoredBullets { get { return _maxStoredBullets; } set { _maxStoredBullets = value; } }
        public int CurrentChamberBullets { get { return _currentChamberBullets; } set { _currentChamberBullets = value; } }
        public int CurrentStoredBullets { get { return _currentStoredBullets; } set { _currentStoredBullets = value; } }
        // Type
        public WeaponType WeaponType { get { return _weaponType; } set { _weaponType = value; } }
        public SubType SubType { get { return _weaponSubType; } set { _weaponSubType = value; } }
        public ActionType ActionType { get { return _actionType; } set { _actionType = value; } }
        // Visuals
        public Mesh WeaponMesh { get { return _weaponMesh; } set { _weaponMesh = value; } }
        #endregion
    }

    public enum WeaponType
    {
        MELEE,
        RANGED,
        THROWABLE
    }

    public enum SubType
    {
        LIGHT,
        MEDIUM,
        HEAVY
    }

    public enum ActionType
    {
        NONE,
        MANUAL,
        SEMI_AUTO,
        FULLY_AUTO
    }
}
