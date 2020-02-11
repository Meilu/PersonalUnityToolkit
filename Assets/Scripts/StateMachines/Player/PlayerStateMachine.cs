using System;
using StateMachines.Locations;

namespace StateMachines.Player
{

  [Serializable]
  public class PlayerStateMachine: BaseStateMachine<PlayerStateStatus, PlayerState>, ICloneable
  {
    
    public override bool Advance(PlayerStateStatus newStateType)
    {
      CurrentState.Advance(newStateType);
      OnStateChanged(newStateType, CurrentState);

      return true;
    }

    public PlayerStateMachine(PlayerState state) : base(state) { }
    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
