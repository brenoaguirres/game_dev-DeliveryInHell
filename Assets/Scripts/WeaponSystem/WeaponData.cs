using UnityEngine;

namespace CBPXL.WeaponSystem
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
    public class WeaponData : ScriptableObject
    {
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
        MANUAL, // revolvers and handguns
        BOLT_ACTION, // sniper
        PUMP_ACTION, // shotgun
        SEMI_AUTO,
        FULLY_AUTO
    }
}
