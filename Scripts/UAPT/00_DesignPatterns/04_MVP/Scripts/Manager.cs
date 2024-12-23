using UnityEngine;

namespace BIS.Managers
{
    public class Manager : MonoBehaviour
    {
        private static Manager s_inctance;
        private static Manager Instacne
        {
            get
            {
                Init();
                return s_inctance;
            }
        }

        public static GameObject GO { get; set; }

        private GameSceneManager _gameScene = new GameSceneManager();
        private GameManager _game = new GameManager();
        private CameraManager _camera = new CameraManager();

        public static GameSceneManager GameScene { get { return Instacne._gameScene; } }
        public static CameraManager Camera { get { return Instacne._camera; } }
        public static GameManager Game { get { return Instacne._game; } }
        private static void Init()
        {
            if (s_inctance == null)
            {
                GO = GameObject.Find("@Manager");
                if (GO == null)
                {
                    GO = new GameObject { name = "@Manager" };
                    GO.AddComponent<Manager>();
                }

                DontDestroyOnLoad(GO);

                //√ ±‚»≠
                s_inctance = GO.GetComponent<Manager>();
            }
        }
    }

}
