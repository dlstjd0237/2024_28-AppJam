using BIS.Core;
using BIS.Entities;
using BIS.FSM;
using BIS.Inputs;
using BIS.Managers;
using BIS.Stats;
using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BIS.Players
{
    public class Player : Entity
    {
        [field: SerializeField] public Transform AttackTrm { get; private set; }
        [field: SerializeField] public GameObject Ball { get; private set; }
        [Header("Stats")]

        public List<StateSO> states;

        private int _jumpCount;
        private StateMachine _stateMachine;


        public float CurrentJumpCount { get; private set; }
        public bool CanAirJump => CurrentJumpCount > 0;


        protected override void AfterInitialize()
        {
            base.AfterInitialize(); //모든 컴포넌트와 이벤트 구독 완료 상태
            _stateMachine = new StateMachine(states, this);
            _jumpCount = Stat.jumpCount.GetValue();
            CurrentJumpCount = _jumpCount;
            EntityHealth health = GetCompo<EntityHealth>();
            health.OnDead += HandleDeadEvent;
            health.OnHit += HandleHitEvent;

        }

        private void HandleHitEvent()
        {
            GetCompo<EntityRenderer>().SpriteRenderer.sprite = SkinSO.PlayerSkinHitSprite;
            DOVirtual.DelayedCall(0.5f, () =>
            {
                GetCompo<EntityRenderer>().SpriteRenderer.sprite = SkinSO.playerSkinSprite;
            });
            //AudioManager.Instance.PlaySound("NpcHit", transform, 1, 1);
        }
        private void OnDisable()
        {
            EntityHealth health = GetCompo<EntityHealth>();
            health.OnDead -= HandleDeadEvent;
            health.OnHit -= HandleHitEvent;
            _stateMachine.AllDestory();
        }
        private void HandleDeadEvent()
        {
            Manager.Game.SetWinner(_playerType == Core.Define.EObjectTag.Player ? Core.Define.EObjectTag.Enemy : Core.Define.EObjectTag.Player);
            SceneControlManager.FadeOut(() => SceneManager.LoadScene(Define.SceneName.WinnerScene));
        }

        private void Start()
        {
            _stateMachine.Initalize("IDLE"); //IDLE상태로 시작
        }

        private void Update()
        {
            _stateMachine.UpdateFSM();
        }

        public void ChangeState(string newStateName)
        {
            _stateMachine.ChangeState(newStateName);
        }
        public GameObject SpawnBall()
        {
            return Instantiate(Ball, AttackTrm.position, Quaternion.identity);
        }

        public void DecreaseJumpCount() => CurrentJumpCount--;
        public void ResetJumpCount() => CurrentJumpCount = _jumpCount; //todo : Stat으로 변경 예정
    }
}
