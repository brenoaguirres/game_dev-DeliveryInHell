using System;
using CBPXL.InspectionSystem;
using CBPXL.InteractSystem;
using UnityEngine;

namespace CBPXL.ClimbingSystem
{
    public class VerticalLadder : MonoBehaviour, IInspectable
    {
        #region FIELDS
        [Header("Active Status")]
        [SerializeField] private bool isClimbing = false;

        [Space(2)]
        [Header("Player Info")]
        [SerializeField] private string _playerTag = "Player";
        [SerializeField] private Transform _climberPosition;
        [SerializeField] private GameObject _player;

        #endregion

        #region PROPERTIES
        public Transform ClimberPosition { get { return _climberPosition; } set { _climberPosition = value; } }
        #endregion

        #region EVENTS
        public Action CLIMB_START;
        public Action CLIMB_END;
        #endregion

        #region DEFAULT METHODS
        // need a collision notifier that will pass a list of colliders events, 0 is bottom col, 1 is upper col
        #endregion

        #region CUSTOM METHODS
        public void ClimbStart()
        {
            isClimbing = true;
            CLIMB_START?.Invoke();
        }

        public void ClimbEnd()
        {
            isClimbing = false;
            CLIMB_END?.Invoke();
        }

        public void OnPlayerJump()
        {
            ClimbEnd();
        }

        public void OnPlayerMove()
        {
            UpdateClimberPosition();
        }

        public void UpdateClimberPosition()
        {

        }
        #endregion

        #region IInspectable METHODS
        public void OnInspect()
        {
            // here we notify the answer to the player that he has looked to a vertical ladder and must enter ClimbLadder state
            // player must return himself as an object to this, then vinculate ON_PRESS_UP, ON_PRESS_DOWN, ON_PRESS_JUMP events to the methods here.
            // parent player to _climberPosition var
            // climb ladder state should read up / down / jump inputs
            // up / down input -> here will move the _climberPosition up / down
            //      also on player will toggle climbLadder animation and turn him facing the side of the ladder
            // jump input -> climb end here, devinculate all
            //      on player will transition to jump state, turn player to the side
            //
            // if player reaches top collider and is pressing up then end climbing, also if reaches bottom collider and is pressing down end climbing.
        }
        #endregion
    }
}