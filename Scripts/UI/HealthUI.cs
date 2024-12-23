using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using BIS.Utility;
using TMPro;
using BIS.Players;
using static BIS.Core.Define;
using BIS.Managers;

namespace BIS.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private EObjectTag _tag;
        [SerializeField] private Image _profileImage;
        [SerializeField] private Image _fill;
        [SerializeField] private TextMeshProUGUI _text;



        private void Start()
        {
            if (_tag == EObjectTag.Player)
            {
                Debug.Log(Manager.Game.p1);
                _profileImage.sprite = Manager.Game.p1.playerSkinSprite;
            }
            else if (_tag == EObjectTag.Enemy)
            {
                Debug.Log(Manager.Game.p2);
                _profileImage.sprite = Manager.Game.p2.playerSkinSprite;
            }
        }

        public void HelathChange(float currentValue, float maxValue)
        {
            float percentage = (currentValue / maxValue);
            _fill.DOFillAmount(percentage, 0.5f);
            _text.text = $"{percentage * 100:F1}%";
        }

    }
}
