using System;
using System.Collections.Generic;
using Zenject;

public class GameStateMachine
{
    readonly DiContainer _container;
    readonly SignalBus _signalBus;

    Dictionary<Type, IGameState> _states = new();
    IGameState _active;

    public GameStateMachine(DiContainer container, SignalBus signalBus)
    {
        _container = container;
        _signalBus = signalBus;

        RegisterState<MainMenuState>();
        RegisterState<GameplayState>();
    }

    void RegisterState<T>() where T : IGameState
    {
        _states[typeof(T)] = _container.Instantiate<T>();
    }

    public void Enter<T>() where T : IGameState
    {
        _active?.Exit();
        _active = _states[typeof(T)];
        _active.Enter();
        _signalBus.Fire(new GameStateChangedSignal(typeof(T)));
    }
}