using GameArchitecture.DI;
using GameArchitecture.InputSystem;
using UnityEngine;

namespace GameArchitecture.GameStateMachine.States
{
  public class BootstrapState : IState
  {
    private const string InitialSceneName = "InitialScene";
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(StateMachine stateMachine, SceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
      RegisterServices();
      _sceneLoader.Load(InitialSceneName, EnterLoadMainScene);
    }

    private void EnterLoadMainScene()
    {
      
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
