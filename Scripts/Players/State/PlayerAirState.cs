using BIS.Animators;
using BIS.Entities;
using BIS.FSM;
using System;
using UnityEngine;

namespace BIS.Players
{
    public class PlayerAirState : EntityState
    {
        protected EntityMover _mover;
        protected Player _player;
        protected PlayerInputRoolSO _input;
        public PlayerAirState(Entity entity, AnimParamSO stateAnimParam) : base(entity, stateAnimParam)
        {
            _player = entity as Player;
            _mover = entity.GetCompo<EntityMover>();
            _input = entity.PlayerInput;
        }
        public override void Enter()
        {
            base.Enter();
            _mover.SetMovementMultiplier(0.7f);
            _input.JumpEvent += HandleAirJump;
        }

        public override void Exit()
        {
            _mover.SetMovementMultiplier(1.0f);
            _mover.StopImmediately();

            _input.JumpEvent -= HandleAirJump;
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            float xInput = _input.InputDirection.x;
            if (Mathf.Abs(xInput) > 0)
                _mover.SetMovement(xInput);
        }

        private void HandleAirJump()
        {
            //플레이어가 더블점프 가능한지 체크 하고 점프

            if (_player.CanAirJump)
                _player.ChangeState("JUMP");
        }


    }
}
