
using System;

namespace StateMachines.Worlds
{
 
  [Serializable]
  public class WorldStateMachine: BaseStateMachine<WorldStateStatus, WorldState>
  {
    public override bool Advance(WorldStateStatus newState)
    {
      CurrentState.CurrentStateType = newState;
      return true;
    }

    public WorldStateMachine(WorldState state) : base(state) { }
  }
}
