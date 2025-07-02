using UnityEngine.SceneManagement;

public class GameplayState : IGameState
{
    public void Enter() => SceneManager.LoadScene("Gameplay");
    public void Exit() { }
}