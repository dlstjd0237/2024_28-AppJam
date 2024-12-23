using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static ControlsP2;
namespace BIS.Inputs
{

    [CreateAssetMenu(fileName = "P2PlayerInputSO", menuName = "SO/Player/P2InputSO")]
    public class PlayerP2InputSO : PlayerInputRoolSO, IPlayerActions
    {


        private ControlsP2 _controls;

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new ControlsP2();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }
        public void SetPlayerInput(bool isEnable)
        {
            if (isEnable)
                _controls.Player.Enable();
            else
                _controls.Player.Disable();
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

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                JumpEvent?.Invoke();
        }
    }
}
