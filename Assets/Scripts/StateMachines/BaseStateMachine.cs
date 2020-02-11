using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace StateMachines
{

  [Serializable]
  public abstract class BaseStateMachine<TStateType, TState> where TStateType: Enum
  {
    public TState CurrentState { get; protected set; }
    public abstract bool Advance(TStateType newState);
   
    public delegate void StateAdvancedEventDelegate(TStateType newStateType, TState state);
    
    [field:NonSerializedAttribute()] 
    public event StateAdvancedEventDelegate StateAdvancedEvent;

    public BaseStateMachine(TState state)
    {
      CurrentState = state;
    }
    
    protected virtual void OnStateChanged(TStateType stateType, TState state)
    {
      StateAdvancedEvent?.Invoke(stateType, state);
    }
  }
}
