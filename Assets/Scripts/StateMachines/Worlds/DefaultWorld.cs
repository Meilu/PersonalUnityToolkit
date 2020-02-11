using System;
using DataModels;
using StateMachines.Locations;

namespace StateMachines.Worlds
{

  [Serializable]
  public class DefaultWorldStateMachine: WorldStateMachine
  {
    public DefaultWorldStateMachine(WorldState state) : base(state) { }
  }
}
