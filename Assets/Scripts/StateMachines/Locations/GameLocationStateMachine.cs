using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using DataModels;
using UnityEngine;

namespace StateMachines.Locations
{
  [Serializable]
  public class GameLocationStateMachine: BaseStateMachine<GameLocationStateStatus, GameLocationState>, ICloneable
  {
    
    public GameLocationStateMachine(GameLocationState model) : base(model) { }
    
    public override bool Advance(GameLocationStateStatus newStateType)
    {
      var possibleTransition = CurrentState.PossibleStateTransitions().ToList();
      
      if (!possibleTransition.Exists(x => x == newStateType))
        return false;
      
      CurrentState.CurrentStateType = newStateType;
      OnStateChanged(newStateType, CurrentState);
      
      return true;
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
