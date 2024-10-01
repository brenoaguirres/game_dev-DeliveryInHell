using UnityEngine;

namespace CBPXL.ControllableCharacter
{
    public class AttackPlayer : MonoBehaviour
    {
        #region FIELDS
        [Header("Animator Variable Strings")]
        [SerializeField] private string animAimString = "isAiming";
        [SerializeField] private string animVInputString = "verticalInput";
        #endregion

        #region PROPERTIES
        #endregion

        #region REFERENCES
        private Animator animator;
        #endregion

        #region STATE MACHINE
        private enum AttackPhases
        {
            IDLE,
            AIMING,
            SHOOTING,
            RELOADING,

        }
        AttackPhases attackPhases = AttackPhases.IDLE;
        #endregion

        #region DEFAULT METHODS
        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
        }
        #endregion

        #region CUSTOM METHODS
        public void UpdateAttack(bool aimInput, bool shootInput, float verticalInput)
        {
            UpdateStateMachine();
            UpdateBehavior();
            UpdateAnimations(aimInput, shootInput, verticalInput);
        }
        private void UpdateAnimations(bool aim, bool shoot, float verticalInput)
        {
            animator.SetBool(animAimString, aim);
            animator.SetFloat(animVInputString, verticalInput);
        }
        private void UpdateStateMachine()
        {

        }
        private void UpdateBehavior()
        {

        }
        #endregion
    }
}
