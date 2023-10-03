using UnityEngine;

namespace GameArchitecture.GameStateMachine.States
{
    public interface IState : IExitState
    {
        void Enter();
    }
    
    public interface IPayloadedState<TPayload> : IExitState
    {
        void Enter(TPayload payload);
    }

    public interface IExitState
    {
        void Exit();
    }
}
