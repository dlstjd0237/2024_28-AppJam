using BIS.Animators;
using BIS.Entities;
using BIS.FSM;
using UnityEngine;

namespace BIS.Players
{
    public class PlayerMoveState : PlayerGroundState
    {
        public PlayerMoveState(Entity entity, AnimParamSO stateAnimParam) : base(entity, stateAnimParam)
        {
        }


        public override void Update()
        {
            base.Update();
            if (_inputSO.InputDirection.x == 0)
            {
                _player.ChangeState("IDLE");
            }
            _mover.SetMovement(_inputSO.InputDirection.x);
        }
    }
}
