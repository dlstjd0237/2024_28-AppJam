using UnityEngine;
using UnityEngine.UI;
using System;
using static BIS.Core.Define;
using BIS.Players;
using TMPro;
using UnityEngine.SceneManagement;
using BIS.Core;
using BIS.Managers;
using DG.Tweening;
using UAPT.UI;


namespace BIS
{

    [Serializable]
    public class PlayerUI
    {
        public Image _mainImage;
    }

    public class PlayerChoiceUI : MonoBehaviour
    {
        [SerializeField] private PlayerUI _p1, _p2;
        [SerializeField] private Button _choiceButton;
        [SerializeField] private TextMeshProUGUI _choiceButtonText;
        [SerializeField] private CanvasGroup _playerCanvasGroup, _mapCanvasGroup;
        [SerializeField] private EObjectTag _currentTurn;

        public EObjectTag CurrentTurn => _currentTurn;


        private void Awake()
        {
            _choiceButton.onClick.AddListener(HandleSkinChoice);
            FixedScreen.FixedScreenSet();
        }

        private void HandleSkinChoice()
        {
            Manager.Camera.ShakeCamera(Vector2.one * 5, 5, 5, 0.2f);



            if (_currentTurn == EObjectTag.Player)
            {
                if (_p1._mainImage.sprite == null)
                    return;
                _currentTurn = EObjectTag.Enemy;
            }
            else if (_currentTurn == EObjectTag.Enemy)
            {
                if (_p2._mainImage.sprite == null)
                    return;
                _currentTurn = EObjectTag.All;
                AllChoice();
            }
            else if (_currentTurn == EObjectTag.All)
            {
                GameStart();
            }
        }

        public void SetSkin(PlayerSkinSO so, EObjectTag Trun)
        {
            if (Trun == EObjectTag.Player)
            {
                _p1._mainImage.sprite = so.playerSkinSprite;
                Manager.Game.SetPlayerSkin(Trun, so);
            }
            if (Trun == EObjectTag.Enemy)
            {
                _p2._mainImage.sprite = so.playerSkinSprite;
                Manager.Game.SetPlayerSkin(Trun, so);
            }
        }

        private void GameStart()
        {
            _playerCanvasGroup.DOFade(0, 1);
            _playerCanvasGroup.interactable = false;
            _playerCanvasGroup.blocksRaycasts = false;

            //SceneControlManager.FadeOut(delegate { SceneManager.LoadScene(Define.SceneName.GameScene); });
            _mapCanvasGroup.DOFade(1, 3);
            _mapCanvasGroup.interactable = true;
            _mapCanvasGroup.blocksRaycasts = true;
        }

        private void AllChoice()
        {
            _choiceButtonText.text = "START";
            _choiceButton.GetComponent<Image>().color = Color.white;
        }
    }
}
