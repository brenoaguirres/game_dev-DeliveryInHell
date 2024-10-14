using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateAim : ControllableCharacterState
    {
        #region CONSTRUCTOR

        public ControllableCharacterStateAim(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
        {
        }

        #endregion

        #region STATE METHODS

        public override void EnterState()
        {
            Ctx.Data.Animator.SetBool("Aim", true);
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
            UpdateAim();
        }

        public override void FixedUpdateState()
        {
        }

        public override void ExitState()
        {
        }

        public override void CheckSwitchStates()
        {
            if (!Ctx.Input.AimInput)
            {
                SwitchState(Factory.Idle());
            }
        }

        public override void InitializeSubState()
        {
        }

        #endregion

        #region BEHAVIOR METHODS
        public void UpdateAim()
        {
            if (Ctx.Input.AimPosInput <= Ctx.Data.LowerAimMouseThreshold)
            {
                Debug.Log("Aim Down");
            }
            else if (Ctx.Input.AimPosInput >= Ctx.Data.UpperAimMouseThreshold)
            {
                Debug.Log("Aim Up");
            }
            else
            {
                Debug.Log("Aim Middle");
            }
        }
        #endregion
    }
}
