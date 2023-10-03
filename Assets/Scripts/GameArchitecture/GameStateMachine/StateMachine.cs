using System;
using System.Collections.Generic;
using GameArchitecture.DI;
using GameArchitecture.GameStateMachine.States;

namespace GameArchitecture.GameStateMachine
{
  public class StateMachine
  {
    private readonly Dictionary<Type, IExitState> _states;
    private IExitState _currentState;

    public StateMachine(SceneLoader sceneLoader)
    {
      _states = new Dictionary<Type, IExitState>
      {
        [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
        [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader),
      };
    }

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
      TState state = ChangeState<TState>();
      state.Enter(payload);
    }
    
    private TState ChangeState<TState>() where TState : class, IExitState
    {
      _currentState?.Exit();
      
      TState state = GetState<TState>();
      _currentState = state;
      
      return state;
    }

    private TState GetState<TState>() where TState : class, IExitState => 
      _states[typeof(TState)] as TState;

  }
}
