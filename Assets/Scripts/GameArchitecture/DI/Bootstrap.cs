using GameArchitecture.GameStateMachine.States;
using UnityEngine;

namespace GameArchitecture.DI
{
  public class Bootstrap : MonoBehaviour, ICoroutineRunner
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game(this);
      _game.StateMachine.Enter<BootstrapState>();
      
      DontDestroyOnLoad(this);
    }
  }
}