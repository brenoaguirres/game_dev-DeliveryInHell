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
        if (!_ctx.Input.HorizontalInput)
        {
            SetSubState(_factory.Idle());
        }
        else if (_ctx.Input.HorizontalInput && !_ctx.Input.RunInput)
        {
            SetSubState(_factory.Walk());
        }
    }

    public override void InitializeSubState()
    {
    }
    #endregion
}
