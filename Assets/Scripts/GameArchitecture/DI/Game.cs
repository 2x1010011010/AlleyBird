using System.Net.Mime;
using GameArchitecture.GameStateMachine;
using GameArchitecture.InputSystem;
using UnityEngine;

namespace GameArchitecture.DI
{
  public class Game
  {
    public static IInput InputService;
    public StateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner)
    {
      StateMachine = new StateMachine(new SceneLoader(coroutineRunner));
    }
  }
}