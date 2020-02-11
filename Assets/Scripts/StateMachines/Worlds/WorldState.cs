using System;
using System.Collections.Generic;
using System.Linq;
using DataModels;
using StateMachines.Locations;
using StateMachines.Player;
using StateMappers;

namespace StateMachines.Worlds
{

  public enum WorldStateStatus
  {
    Loading,
    Entering,
    Idle
  }
  
  [Serializable]
  public class WorldState: IState<WorldStateStatus, World>
  {
    public WorldStateStatus CurrentStateType { get; set; }
    public World DataModel { get; }
    
    public List<GameLocationStateMachine> Locations { get; }

    public WorldState(World model)
    {
      DataModel = model;

      Locations = model.GameLocations.Select(GameLocationStateMachineMapper.CreateLocationStateFromLocation).ToList();
    }

    public void Update()
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<WorldStateStatus> PossibleStateTransitions()
    {
      throw new System.NotImplementedException();
    }

    public bool IsPossibleTravelLocation(GameLocationStateMachine newLocation)
    {
      return GetPossiblePlayerTravelLocations().Exists(x => x == newLocation);
    }
    
    public List<GameLocationStateMachine> GetPossiblePlayerTravelLocations()
    {
      return Locations.Where(x => x.CurrentState.Player == null && !x.CurrentState.DataModel.Hidden).ToList();
    }
    
    public GameLocationStateMachine GetCurrentGameLocationOfPlayer()
    {
      return Locations.FirstOrDefault(x => x.CurrentState.Player != null);
    }

    public PlayerStateMachine GetPlayer()
    {
      return GetCurrentGameLocationOfPlayer().CurrentState.Player;
    }
  }
}
