using BIS.Players;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using BIS.Init;
using System;

namespace BIS.UI
{
    public class PlayerSkinUI : InitBase
    {
        [SerializeField] private PlayerChoiceUI _choiceUI;
        [SerializeField] private PlayerSkinSO _skinSO;
        [SerializeField] private Image _skinImage;
        [SerializeField] private Image _choiceImage;
        [SerializeField] private Button _choiceButton;
        [SerializeField] private TextMeshProUGUI _nameText;

        public override bool Init()
        {
            if (base.Init() == false)
                return false;

            _choiceButton.onClick.AddListener(HandleClickEvent);

            return true;
        }

        private void HandleClickEvent()
        {
            if (_choiceUI.CurrentTurn == Core.Define.EObjectTag.Player)
            {
                _choiceUI.SetSkin(_skinSO,Core.Define.EObjectTag.Player);
            }

            if (_choiceUI.CurrentTurn == Core.Define.EObjectTag.Enemy)
            {
                _choiceUI.SetSkin(_skinSO, Core.Define.EObjectTag.Enemy);
            }
        }

        private void OnValidate()
        {
            if (_skinSO != null)
            {
                _nameText.text = _skinSO.SkinName;
                _skinImage.sprite = _skinSO.playerSkinSprite;
            }
        }
    }
}
