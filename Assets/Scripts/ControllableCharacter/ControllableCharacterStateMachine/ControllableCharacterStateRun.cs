using CBPXL.ControllableCharacter.ControllableCharacterStateMachine;
using UnityEngine;

public class ControllableCharacterStateRun : ControllableCharacterState
{
    #region CONSTRUCTOR
    public ControllableCharacterStateRun (ControllableCharacterStateMachine currentContext,
        ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
    {
    }
    #endregion
    
    #region STATE METHODS
    public override void EnterState()
    {
    }
        
    public override void UpdateState()
    {
            
    }

    public override void ExitState()
    {
    }

    public override void CheckSwitchStates()
    {
        if (!(Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05))
        {
            SetSubState(Factory.Idle());
        }
        else if ((Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05) && !Ctx.Input.RunInput)
        {
            SetSubState(Factory.Walk());
        }
    }

    public override void InitializeSubState()
    {
    }
    #endregion
}
