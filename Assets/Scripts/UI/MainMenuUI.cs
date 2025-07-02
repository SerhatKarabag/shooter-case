using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button startButton;

    GameStateMachine _stateMachine;

    [Inject]
    void Construct(GameStateMachine sm) => _stateMachine = sm;

    void Awake() => startButton.onClick.AddListener(OnStart);

    void OnStart() => _stateMachine.Enter<GameplayState>();
}