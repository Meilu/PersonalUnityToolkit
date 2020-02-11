using System;
using StateMachines.Locations;

namespace StateMachines.Player
{

  [Serializable]
  public class DefaultPlayerStateMachine: PlayerStateMachine
  {
    public DefaultPlayerStateMachine(PlayerState state) : base(state) { }
  }
}
