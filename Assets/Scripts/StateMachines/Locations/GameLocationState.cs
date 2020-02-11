using System;
using System.Collections.Generic;
using System.Linq;
using DataModels;
using StateMachines.Player;
using StateMappers;

namespace StateMachines.Locations
{

  public enum GameLocationStateStatus
  {
    Entering,
    Idle,
    Exiting,
    None
  }
  
  [Serializable]
  public class GameLocationState: IState<GameLocationStateStatus, GameLocation>, ICloneable
  {
    public GameLocationStateStatus CurrentStateType { get; set; }
    public GameLocation DataModel { get; }

    public PlayerStateMachine Player { get; set; }
    
    public GameLocationState(GameLocation model)
    {
      DataModel = model;
      
      if (model.Player != null)
        Player = PlayerStateMachineMapper.MapPlayer(model.Player);
    }

    public void Update()
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<GameLocationStateStatus> PossibleStateTransitions()
    {
      // No checks in place, just return every possibility
      return Enum.GetValues(typeof(GameLocationStateStatus)).Cast<GameLocationStateStatus>();
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
