using BIS.Core;
using BIS.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    [SerializeField] private MapSO _mapSO;
    private Image _image;
    private TextMeshProUGUI _text;

    private Button _btn;

    private void Awake()
    {
        _btn = GetComponent<Button>();
        _image = _btn.GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _btn.onClick.AddListener(HandleClickEvent);
    }

    private void OnDestroy()
    {
        _btn.onClick.RemoveListener(HandleClickEvent);
    }

    private void HandleClickEvent()
    {
        Manager.Game.SetMap(_mapSO);
        SceneControlManager.FadeOut(() => SceneManager.LoadScene(Define.SceneName.GameScene));
    }

    private void OnValidate()
    {
        if (_mapSO != null)
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
            _image = GetComponent<Image>();
            _image.sprite = _mapSO.MapSprite;
            _text.text = _mapSO.MapName;
        }
    }
}
