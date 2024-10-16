using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateLookUp : ControllableCharacterState
    {
        #region CONSTRUCTOR
        public ControllableCharacterStateLookUp(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
        {
        }
        #endregion

        #region STATE METHODS

        public override void EnterState()
        {
            Ctx.Data.Animator.SetBool("LookUp", true);
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
            UpdateLookUp();
        }

        public override void FixedUpdateState()
        {
        }

        public override void ExitState()
        {
            
            Ctx.Data.Animator.SetBool("LookUp", false);
        }

        public override void CheckSwitchStates()
        {
            if (!Ctx.Input.LookUpInput)
            {
                SwitchState(Factory.Idle());
            }
        }

        public override void InitializeSubState()
        {
        }

        #endregion

        #region BEHAVIOR METHODS

        private void UpdateLookUp()
        {
            //Ctx.Data.Interactor.Interacting = true;
            //Ctx.Data.Interactor.Interact();
        }

        #endregion
    }
}
