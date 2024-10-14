using CBPXL.InteractSystem;
using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateInteract : ControllableCharacterState
    {
        #region FIELDS
        private bool _isInteracting = false;
        #endregion

        #region CONSTRUCTOR
        public ControllableCharacterStateInteract(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
        {
        }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            _isInteracting = true;
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
            UpdateInteraction();
        }
        public override void FixedUpdateState()
        {
        }

        public override void ExitState()
        {
        }

        public override void CheckSwitchStates()
        {
            if (!_isInteracting)
            {
                SwitchState(Factory.Idle());
            }
        }

        public override void InitializeSubState()
        {
        }
        #endregion

        #region BEHAVIOR METHODS
        private void UpdateInteraction()
        {
            Ctx.Data.Interactor.Interacting = true;
            Ctx.Data.Interactor.Interact();
            _isInteracting = false;
        }
        #endregion
    }
}
