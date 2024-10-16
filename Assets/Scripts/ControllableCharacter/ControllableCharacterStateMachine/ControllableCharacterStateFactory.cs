namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateFactory
    {
        #region REFERENCES

        private ControllableCharacterStateMachine _context;

        #endregion

        #region CONSTRUCTOR

        public ControllableCharacterStateFactory(ControllableCharacterStateMachine currentContext)
        {
            _context = currentContext;
        }

        #endregion

        #region STATES

        public ControllableCharacterState Idle()
        {
            return new ControllableCharacterStateIdle(_context, this);
        }

        public ControllableCharacterState Walk()
        {
            return new ControllableCharacterStateWalk(_context, this);
        }

        public ControllableCharacterState Run()
        {
            return new ControllableCharacterStateRun(_context, this);
        }

        public ControllableCharacterState Jump()
        {
            return new ControllableCharacterStateJump(_context, this);
        }

        public ControllableCharacterState Ground()
        {
            return new ControllableCharacterStateGround(_context, this);
        }

        public ControllableCharacterState Fall()
        {
            return new ControllableCharacterStateFall(_context, this);
        }
        
        public ControllableCharacterState Aim()
        {
            return new ControllableCharacterStateAim(_context, this);
        }

        public ControllableCharacterState Interact()
        {
            return new ControllableCharacterStateInteract(_context, this);
        }

        public ControllableCharacterStateShoot Shoot()
        {
            return new ControllableCharacterStateShoot(_context, this);
        }

        public ControllableCharacterStateCrouch Crouch()
        {
            return new ControllableCharacterStateCrouch(_context, this);
        }

        public ControllableCharacterStateCrouchWalk CrouchWalk()
        {
            return new ControllableCharacterStateCrouchWalk(_context, this);
        }

        public ControllableCharacterStateFallWalk FallWalk()
        {
            return new ControllableCharacterStateFallWalk(_context, this);
        }

        public ControllableCharacterStateLookUp LookUp()
        {
            return new ControllableCharacterStateLookUp(_context, this);
        }
        #endregion
    }
}
