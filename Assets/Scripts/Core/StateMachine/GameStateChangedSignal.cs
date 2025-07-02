public class GameStateChangedSignal
{
    public readonly System.Type NewState;
    public GameStateChangedSignal(System.Type newState) => NewState = newState;
}