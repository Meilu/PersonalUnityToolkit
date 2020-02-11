using System;
using DataModels;
using StateMachines.Locations;

namespace StateMappers
{
    public static class GameLocationStateMachineMapper
    {
        public static GameLocationStateMachine CreateLocationStateFromLocation(GameLocation location)
        {
          if (location == null)
            throw new Exception("Location is null");
          
          switch (location.Type)
          {
            default:
              return new DefaultGameLocationStateMachine(new GameLocationState(location));
          }
        }
    }
}