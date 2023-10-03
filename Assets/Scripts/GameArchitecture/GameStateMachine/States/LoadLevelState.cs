using GameArchitecture.DI;

namespace GameArchitecture.GameStateMachine.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public LoadLevelState(StateMachine stateMachine, SceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    public void Enter(string sceneName) =>
        _sceneLoader.Load(sceneName);

    public void Exit()
    {
      throw new System.NotImplementedException();
    }
  }
}