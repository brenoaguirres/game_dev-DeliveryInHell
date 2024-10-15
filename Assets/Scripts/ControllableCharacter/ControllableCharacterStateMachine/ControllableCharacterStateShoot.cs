using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateShoot : ControllableCharacterState
    {
        #region CONSTRUCTOR
        public ControllableCharacterStateShoot(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
        {
        }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            Ctx.Data.Animator.SetBool("Shoot", true);
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
            UpdateShoot();
        }

        public override void FixedUpdateState()
        {
        }

        public override void ExitState()
        {
            Ctx.Data.Animator.SetBool("Shoot", false);
        }

        public override void CheckSwitchStates()
        {
            if (!Ctx.Input.ShootInput)
            {
                SwitchState(Factory.Aim());
            }
        }

        public override void InitializeSubState()
        {
        }

        #endregion

        #region BEHAVIOR METHODS
        public void UpdateShoot()
        {
            Debug.Log("Shoot");
        }
        #endregion
    }
}
