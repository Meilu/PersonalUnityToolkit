using System;
using Game.Player.Commands.Models;
using StateMachines.Locations;

namespace Game.Player.Commands
{
    [Serializable]
    public class MoveCommand : Command<MoveModel>
    {
        public override bool Execute(MoveModel model)
        {
            // Start by saving a copy of the model, with this we can later see what the action contained
            // And revert it or check the entire history of the player's actions if we wanted to.
            Model = model;
            
            // Old location has to contain the player to be able to move
            if (model.OldLocation.CurrentState.Player == null)
                return false;

            // New location cannot contain the player already
            if (model.NewLocation.CurrentState.Player != null)
                return false;

            var player = model.OldLocation.CurrentState.Player;
            
            // Advance to player to the Exiting state, indicating the player will leave the location.
            player.Advance(PlayerStateStatus.Exiting);

            // Unset the player on the old location
            model.OldLocation.CurrentState.Player = null;

            // Set the player to the new location
            model.NewLocation.CurrentState.Player = player;
            
            // Advance the player to the entering state, indicating the player is entering the new location.
            player.Advance(PlayerStateStatus.Entering);
            
            return true;
        }
    }
}
