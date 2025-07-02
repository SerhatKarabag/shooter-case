using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class QuitButton : MonoBehaviour
{
    [SerializeField] Button btn;

    GameStateMachine _gsm;

    [Inject] void Construct(GameStateMachine gsm) => _gsm = gsm;

    void Awake() => btn.onClick.AddListener(OnQuit);

    void OnQuit() => _gsm.Enter<MainMenuState>();
}