using GameArchitecture.DI;

namespace GameArchitecture.GameStateMachine.States
{
  public class LoadLevelState : IState
  {
    private const string _mainSceneName = "MainScene";
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public LoadLevelState(StateMachine stateMachine, SceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
      _sceneLoader.Load(_mainSceneName);
    }

    public void Exit()
    {
      throw new System.NotImplementedException();
    }
  }
}