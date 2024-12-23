using BIS.Animators;
using BIS.Entities;
using BIS.FSM;
using BIS.Players;
using System;
using UnityEngine;

namespace BIS.Players
{
    public class PlayerAttackState : EntityState
    {
        private PlayerInputRoolSO _rootSO;
        private Player _player;
        private EntityMover _mover;
        private EntityAnimatorTrigger _trigger;
        public PlayerAttackState(Entity entity, AnimParamSO stateAnimParam) : base(entity, stateAnimParam)
        {
            _player = entity as Player;
            _trigger = entity.GetCompo<EntityAnimatorTrigger>();
            _mover = entity.GetCompo<EntityMover>();
            _rootSO = entity.PlayerInput;
        }

        private void HandleAttackEnd()
        {
            _player.ChangeState("IDLE");

        }

        public override void Enter()
        {
            base.Enter();
            _mover.StopImmediately();
            _trigger.OnAnimationEnd += HandleAttackEnd;
            AudioManager.Instance.PlaySound("SuddenBoom", _player.transform, 0.7f, 1);
        }

        public override void Exit()
        {
            _trigger.OnAnimationEnd -= HandleAttackEnd;

            base.Exit();
        }





    }
}
