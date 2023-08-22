using UnityEngine;

namespace GameArchitecture.InputSystem
{
  public class MobileInput : InputService
  {
    public override bool IsJumpButtonPressed() =>
      Input.GetMouseButtonDown(0);
  }
}
