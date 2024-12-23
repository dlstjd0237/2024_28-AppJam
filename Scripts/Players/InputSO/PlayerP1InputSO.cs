using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static ControlsP1;

namespace BIS.Inputs
{
    [CreateAssetMenu(fileName = "P1PlayerInputSO", menuName = "SO/Player/P1InputSO")]
    public class PlayerP1InputSO : PlayerInputRoolSO, IPlayerActions
    {
      

        private ControlsP1 _controls;

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new ControlsP1();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
            _controls.UI.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
            _controls.UI.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            InputDirection = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                AttackDownEvent?.Invoke();
            }
            if (context.canceled)
            {
                AttackUpEvent?.Invoke();
            }
        }


        public void SetPlayerInput(bool isEnable)
        {
            if (isEnable)
                _controls.Player.Enable();
            else
                _controls.Player.Disable();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                JumpEvent?.Invoke();
        }
    }

}

