using UnityEngine;
using Unity.Cinemachine;
using BIS.Players;
using BIS.Init;
using BIS.Managers;

namespace BIS.Core
{
    public class Scene : InitBase
    {
        [SerializeField] private CinemachineCamera _cam;

        public override bool Init()
        {
            if (base.Init() == false)
                return false;

            Manager.GameScene.SetMainCamera(_cam);


            return true;
        }
    }
}
