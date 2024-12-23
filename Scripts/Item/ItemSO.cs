using UnityEngine;
using static BIS.Core.Define;

namespace BIS.Item
{

    [CreateAssetMenu(menuName = "SO/BIS/Item")]
    public class ItemSO : ScriptableObject
    {
        private string _itemName; public string ItemName { get { return _itemName; } }
        private Sprite _itemSprite; public Sprite ItemSprite { get { return _itemSprite; } }
        private StatPieceSO _statPiece; public StatPieceSO StatPiece { get { return _statPiece; } }
        private EItemType _itemType; public EItemType ItemType { get { return _itemType; } }
        private EItemRarity _itemRarity; public EItemRarity ItemRarity { get { return _itemRarity; } }
    }
}
