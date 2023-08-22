using System.Net.Mime;
using GameArchitecture.InputSystem;
using UnityEngine;

namespace GameArchitecture.DI
{
  public class Game
  {
    public static IInput InputService;

    public Game()
    {
      RegisterInputService();
    }

    private static void RegisterInputService() =>
      InputService = Application.isEditor ? new DesktopInput() : new MobileInput();
  }
}