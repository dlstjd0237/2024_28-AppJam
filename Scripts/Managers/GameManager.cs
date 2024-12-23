using BIS.Players;
using UnityEngine;
using static BIS.Core.Define;

namespace BIS
{
    public class GameManager
    {
        public PlayerSkinSO p1, p2;
        public MapSO mapSO;
        public EObjectTag winnerTag;

        public void SetPlayerSkin(EObjectTag tag, PlayerSkinSO so)
        {
            if (tag == EObjectTag.Player)
            {
                p1 = so;
            }
            else if (tag == EObjectTag.Enemy)
            {
                p2 = so;
            }
        }

        public void SetMap(MapSO map)
        {
            mapSO = map;
        }

        public void SetWinner(EObjectTag winner)
        {
            winnerTag = winner;
        }
    }
}
