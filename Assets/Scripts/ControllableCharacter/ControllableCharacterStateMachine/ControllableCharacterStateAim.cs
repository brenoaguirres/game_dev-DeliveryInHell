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
            UpdateAim();
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
            Ctx.Data.Animator.SetBool("Aim", false);
        }

        public override void CheckSwitchStates()
        {
            if (Ctx.Input.ShootInput)
            {
                SwitchState(Factory.Shoot());
            }
            else if (!Ctx.Input.AimInput)
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
                Ctx.Data.Animator.SetFloat("AimPos", -1f);
            }
            else if (Ctx.Input.AimPosInput >= Ctx.Data.UpperAimMouseThreshold)
            {
                Ctx.Data.Animator.SetFloat("AimPos", 1f);
            }
            else
            {
                Ctx.Data.Animator.SetFloat("AimPos", 0f);
            }
        }
        #endregion
    }
}
