using BIS.Animators;
using BIS.Entities;
using BIS.FSM;
using BIS.Inputs;
using System;
using UnityEngine;

namespace BIS.Players
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(Entity entity, AnimParamSO stateAnimParam) : base(entity, stateAnimParam)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();
            if (_inputSO.InputDirection.x != 0)
                _player.ChangeState("MOVE");

        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}