using GameArchitecture.DI;
using GameArchitecture.InputSystem;
using UnityEngine;

namespace GameArchitecture.GameStateMachine.States
{
  public class BootstrapState : IState
  {
    private readonly StateMachine _stateMachine;

    public BootstrapState(StateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

    public void Enter()
    {
      RegisterServices();
    }

    public void Exit()
    {
      throw new System.NotImplementedException();
    }
    
    private void RegisterServices()
    {
      Game.InputService = RegisterInputService();
    }
    
    private static IInput RegisterInputService() =>
      Application.isEditor ? new DesktopInput() : new MobileInput();
  }
}
