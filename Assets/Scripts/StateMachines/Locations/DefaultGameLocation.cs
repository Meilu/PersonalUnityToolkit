using System;
using DataModels;

namespace StateMachines.Locations
{
  [Serializable]
  public class DefaultGameLocationStateMachine: GameLocationStateMachine
  {
    public DefaultGameLocationStateMachine(GameLocationState state) : base(state) { }

  }
}
