using BIS.Stats;
using UnityEngine;

namespace BIS.Players
{
    [CreateAssetMenu(menuName = "SO/BIS/SkinSO")]
    public class PlayerSkinSO : ScriptableObject
    {
        [SerializeField] private Sprite _playerSkinSprite; public Sprite playerSkinSprite { get { return _playerSkinSprite; } }
        [SerializeField] private Sprite _playerSkinHitSprite; public Sprite PlayerSkinHitSprite { get { return _playerSkinHitSprite; } }
        [SerializeField] private Sprite _playerProfileSprite; public Sprite playerProfileSprite { get { return _playerProfileSprite; } }
        [SerializeField] private Sprite _playerBananaSprite; public Sprite PlayerBananaSprite { get { return _playerBananaSprite; } }
        [SerializeField] private string _skinName; public string SkinName { get { return _skinName; } }
        [SerializeField] private EntityStat _statSO; public EntityStat StatSO { get { return _statSO; } }
    }
}
