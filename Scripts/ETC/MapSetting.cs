using BIS.Managers;
using UnityEngine;

public class MapSetting : MonoBehaviour
{
    private void Awake()
    {
        Instantiate(Manager.Game.mapSO.Map, transform);
    }
}
