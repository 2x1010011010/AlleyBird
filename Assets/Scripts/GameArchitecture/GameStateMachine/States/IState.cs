using UnityEngine;

namespace GameArchitecture.GameStateMachine.States
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}
