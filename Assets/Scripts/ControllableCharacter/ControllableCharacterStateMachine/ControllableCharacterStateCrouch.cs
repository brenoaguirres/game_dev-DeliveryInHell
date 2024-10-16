using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateCrouch : ControllableCharacterState
    {
        #region CONSTRUCTOR

        public ControllableCharacterStateCrouch(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
        {
        }

        #endregion

        #region STATE METHODS

        public override void EnterState()
        {
            Ctx.Data.Animator.SetBool("Crouch", true);
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
            UpdateCrouch();
        }

        public override void FixedUpdateState()
        {
        }

        public override void ExitState()
        {
            Ctx.Data.Animator.SetBool("Crouch", false);
        }

        public override void CheckSwitchStates()
        {
            if (Ctx.Input.HorizontalInput > 0.05f || Ctx.Input.HorizontalInput < -0.05f)
            {
                SwitchState(Factory.CrouchWalk());
            }
            else if (!Ctx.Input.CrouchInput)
            {
                SwitchState(Factory.Ground());
            }
        }

        public override void InitializeSubState()
        {

        }

        #endregion

        #region BEHAVIOR METHODS

        private void UpdateCrouch()
        {
        }

        #endregion
    }
}