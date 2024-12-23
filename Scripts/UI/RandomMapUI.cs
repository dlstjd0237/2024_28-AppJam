using BIS.Core;
using BIS.Managers;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomMapUI : MonoBehaviour
{
    [SerializeField] private List<MapSO> _mapList;
    private Button _btn;


    private void Awake()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(HandleClickEvent);
    }
    private void OnDestroy()
    {
        _btn.onClick.RemoveListener(HandleClickEvent);

    }
    private void HandleClickEvent()
    {
        Manager.Game.SetMap(_mapList[UnityEngine.Random.Range(0, _mapList.Count)]);
        SceneControlManager.FadeOut(delegate { SceneManager.LoadScene(Define.SceneName.GameScene); });
    }
}
