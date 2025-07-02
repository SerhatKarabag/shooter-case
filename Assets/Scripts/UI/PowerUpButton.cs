using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class PowerUpButton : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PowerUpConfig config;

    [Header("Colors")]
    [SerializeField] private Color selectedColor = new(0.15f, 0.7f, 0.2f);
    [SerializeField] private Color lockedColor = new(0.3f, 0.3f, 0.3f);

    Button _button;
    Image _background;

    [Inject] PowerUpController _controller;

    void Awake()
    {
        _button = GetComponent<Button>();
        _background = GetComponent<Image>();

        _button.onClick.AddListener(OnClick);
    }

    void OnEnable()
    {
        _controller.OnSelected += HandleSelected;
        _controller.OnLimitReached += LockIfNotChosen;
        SetNormal();
    }

    void OnDisable()
    {
        _controller.OnSelected -= HandleSelected;
        _controller.OnLimitReached -= LockIfNotChosen;
    }

    void OnClick() => _controller.Select(config);

    void HandleSelected(PowerUpConfig cfg)
    {
        if (cfg == config)
            SetSelected();
    }

    void LockIfNotChosen()
    {
        if (_background.color != selectedColor)
            SetLocked();
    }

    void SetSelected()
    {
        _button.interactable = false;
        _background.color = selectedColor;
    }

    void SetLocked()
    {
        _button.interactable = false;
        _background.color = lockedColor;
    }

    void SetNormal()
    {
        _button.interactable = true;
        _background.color = _button.colors.normalColor;
    }
}