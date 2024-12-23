using BIS.Animators;
using BIS.Entities;
using BIS.FSM;
using System;
using UnityEngine;



namespace BIS.Players
{
    public class PlayerGroundState : EntityState
    {
        protected Player _player;
        protected PlayerInputRoolSO _inputSO;
        protected EntityMover _mover;
        protected EntityLineRenderer _lineRenderer;
        private bool _isAttack = false;
        private float _currentTime;
        private GameObject _ball;

        float GetPower => _currentTime * _currentTime * -1 + _currentTime + 0.75f;
        float GetAngle => _currentTime * 90;
        public PlayerGroundState(Entity entity, AnimParamSO stateAnimParam) : base(entity, stateAnimParam)
        {
            _player = entity as Player;
            _inputSO = entity.PlayerInput;
            _mover = entity.GetCompo<EntityMover>();
            _lineRenderer = entity.GetCompo<EntityLineRenderer>();
        }


        public override void Enter()
        {
            base.Enter();

            if (_player != null && _inputSO != null)
            {
                _inputSO.AttackDownEvent += HandleAttackDownEvet;
                _inputSO.AttackUpEvent += HandleAttackUpEvent;
                _inputSO.JumpEvent += HandleJumpEvent;
            }


        }

        private void HandleAttackUpEvent()
        {
            if (_player != null && _inputSO != null)
            {
                Debug.Log(_player.transform.rotation.eulerAngles.y);
                float adjustedAngle = _player.transform.rotation.eulerAngles.y == 0 ? GetAngle : 180 - GetAngle;

                Quaternion direction = Quaternion.Euler(0, 0, adjustedAngle);

                _lineRenderer.PredictTrajectory(_ball.transform.position, Vector3.right * 3f + Vector3.up * GetPower);
                Vector2 force = (direction * Vector3.right).normalized * GetPower * 30;
                _ball.GetComponent<Ball>().AddForceToEntity(force, _player.Stat.bulletDamage.GetValue());
                _player.ChangeState("ATTACK");
            }
        }

        public override void Update()
        {
            base.Update();
            if (_player != null && _inputSO != null && _isAttack)
            {
                _currentTime += Time.deltaTime;
                if (_currentTime >= 1) HandleAttackUpEvent();
            }
        }
        private void HandleJumpEvent()
        {
            if (_mover.IsGroundDetected() == true) //���� �پ��ִٸ�
                _player.ChangeState("JUMP");
        }

        int sourceId;
        private void HandleAttackDownEvet()
        {
            if (_player != null)
            {
                _isAttack = true;
                _ball = _player.SpawnBall();
                _ball.GetComponent<Ball>().SetBananaSprite(_player.SkinSO.PlayerBananaSprite);
                _ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                _currentTime = 0;
                sourceId = AudioManager.Instance.PlaySound("Wind", _player.transform, 0.2f, 1);
            }
        }


        public override void Exit()
        {
            if (_player != null && _inputSO != null)
            {
                _inputSO.AttackDownEvent -= HandleAttackDownEvet;
                _inputSO.AttackUpEvent -= HandleAttackUpEvent;
                _inputSO.JumpEvent -= HandleJumpEvent;
            }

            _isAttack = false;
            base.Exit();
        }
    }
}
