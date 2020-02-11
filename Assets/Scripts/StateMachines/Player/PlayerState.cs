using System;
using System.Collections.Generic;
using DataModels;

namespace StateMachines.Locations
{

  public enum PlayerStateStatus
  {
    Entering,
    Idle,
    Exiting,
    None
  }


  [Serializable]
  public class PlayerState: IState<PlayerStateStatus, GamePlayerDataModel>
  {
    public PlayerStateStatus CurrentStateType { get; set; }
    public GamePlayerDataModel DataModel { get; }

    public PlayerState(GamePlayerDataModel model)
    {
      DataModel = model;
    }
    
    public void Advance(PlayerStateStatus newState)
    {

      this.CurrentStateType = newState;
    }

    public void Update()
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<PlayerStateStatus> PossibleStateTransitions()
    {
      throw new System.NotImplementedException();
    }
  }
}
