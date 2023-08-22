using UnityEngine;

namespace GameArchitecture.DI
{
  public class Bootstrap : MonoBehaviour
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game();
      DontDestroyOnLoad(this);
    }
  }
}