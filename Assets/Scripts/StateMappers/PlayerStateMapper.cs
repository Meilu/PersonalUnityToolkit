using System;
using DataModels;
using StateMachines.Locations;
using StateMachines.Player;

namespace StateMappers
{
    public static class PlayerStateMachineMapper
    {
        public static PlayerStateMachine MapPlayer(GamePlayerDataModel player)
        {
          if (player == null)
            throw new Exception("Player is null");
          
          switch (player.Name)
          {
            default:
              return new DefaultPlayerStateMachine(new PlayerState(player));
          }
        }
    }
}