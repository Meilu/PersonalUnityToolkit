using System.Collections.Generic;
using Game.Player.Commands;
using Game.Player.Commands.Models;
using Helpers;
using StateMachines.Locations;
using StateMachines.Worlds;
using UnityEngine;

namespace Game.Player
{
    public class GamePlayer
    {
        private WorldStateMachine _worldStateMachine;
        private List<ICommand> _playerCommandHistory = new List<ICommand>();

        public GamePlayer(WorldStateMachine worldStateMachine)
        {
            _worldStateMachine = worldStateMachine;
        }
        /// <summary>
        /// Moves the player from it's current location to a new location.
        /// </summary>
        /// <param name="newLocation">The new location to move to</param>
        public bool Move(GameLocationStateMachine newLocation)
        {
            var moveCommand = new MoveCommand();
            var oldLocation = _worldStateMachine.CurrentState.GetCurrentGameLocationOfPlayer();
   
            var moveCommandResult = moveCommand.Execute(new MoveModel()
            {
                NewLocation = newLocation,
                OldLocation = oldLocation
            });

            if (!moveCommandResult)
                return false;
            
            _playerCommandHistory.Add(ObjectCopier.Clone(moveCommand));
            
            return true;
        }
    }
}