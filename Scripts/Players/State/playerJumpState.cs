using BIS.Animators;
using BIS.Entities;
using BIS.FSM;
using UnityEngine;

namespace BIS.Players
{
    public class PlayerJumpState : PlayerAirState
    {
        public PlayerJumpState(Entity entity, AnimParamSO stateAnimParam) : base(entity, stateAnimParam)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _mover.StopImmediately();
            _player.DecreaseJumpCount();
            _mover.OnMovement += HandleVelocityChange;
            _mover.AddForceToEntity(Vector2.up * _entity.Stat.jumpPower.GetValue());
        }

        private void HandleVelocityChange(Vector2 obj)
        {
            if (obj.y < 0)
                _player.ChangeState("FALL"); //떨어지는 상태로 변경
        }

        public override void Exit()
        {
            _mover.OnMovement -= HandleVelocityChange;
            base.Exit();
        }
    }

}
