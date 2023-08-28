using System;
using System.Collections.Generic;
using GameArchitecture.GameStateMachine.States;

namespace GameArchitecture.GameStateMachine
{
  public class StateMachine
  {
    private readonly Dictionary<Type, IState> _states;
    private IState _currentState;

    public StateMachine()
    {
      _states = new Dictionary<Type, IState>
      {
        [typeof(BootstrapState)] = new BootstrapState(this),
      };
    }

    public void Enter<TState>() where TState : IState
    {
      _currentState?.Exit();
      var state = _states[typeof(TState)];
      state.Enter();
      _currentState = state;
    }
  }
}
