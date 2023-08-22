using UnityEngine;

namespace GameArchitecture.InputSystem
{
    public class DesktopInput : InputService
    {
        public override bool IsJumpButtonPressed() =>
            Input.GetKeyDown(KeyCode.Space);
    }
}
