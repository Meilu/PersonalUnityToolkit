using System;
using DataModels;
using StateMachines.Worlds;

namespace StateMappers
{
    public class WorldStateMachineMapper
    {
        public static WorldStateMachine MapWorld(World world)
        {
          if (world == null)
            throw new Exception("Cannot map, World is null");

          return new DefaultWorldStateMachine(new WorldState(world));
        }
    }
}