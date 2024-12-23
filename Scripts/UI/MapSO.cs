using UnityEngine;

[CreateAssetMenu(menuName = "SO/BIS/Map")]
public class MapSO : ScriptableObject
{
    [SerializeField] private GameObject _map; public GameObject Map { get { return _map; } }
    [SerializeField] private string _mapName; public string MapName { get { return _mapName; } }
    [SerializeField] private Sprite _mapSprite; public Sprite MapSprite { get { return _mapSprite; } }
}
