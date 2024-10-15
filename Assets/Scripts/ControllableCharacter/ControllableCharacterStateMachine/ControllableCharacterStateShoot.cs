using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateShoot : ControllableCharacterState
    {
        #region EVENTS
        private Action GUN_UNLOCK;
        #endregion

        #region CONSTRUCTOR
        public ControllableCharacterStateShoot(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
        {
        }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            GUN_UNLOCK += OnGunUnlock;

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
            GUN_UNLOCK -= OnGunUnlock;

            Ctx.Data.Animator.SetBool("Shoot", false);
        }

        public override void CheckSwitchStates()
        {
            if (!Ctx.Input.ShootInput && Ctx.Data.CanShoot)
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
            if (Ctx.Data.RangedWeapon.ActionType == WeaponSystem.ActionType.SEMI_AUTO)
            {
                if (Ctx.Data.CanShoot)
                {
                    Debug.Log("Shoot");
                    Ctx.Data.CanShoot = false;
                }
                else if (!Ctx.Data.GunLocked)
                {
                    Ctx.StartCoroutine(WaitCooldown(Ctx.Data.RangedWeapon.FireRate * Ctx.Data.One));
                }
            }
            else if (Ctx.Data.RangedWeapon.ActionType == WeaponSystem.ActionType.FULLY_AUTO)
            {

            }
            
        }

        public IEnumerator WaitCooldown(float seconds)
        {
            Ctx.Data.GunLocked = true;
            yield return new WaitForSeconds(seconds);
            GUN_UNLOCK?.Invoke();
        }

        public void OnGunUnlock()
        {
            Ctx.Data.CanShoot = true;
            Ctx.Data.GunLocked = false;
        }
        #endregion
    }
}
