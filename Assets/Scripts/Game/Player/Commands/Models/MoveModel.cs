using System;
using StateMachines.Locations;

namespace Game.Player.Commands.Models
{

    [Serializable]
    public class MoveModel
    {
        public GameLocationStateMachine OldLocation { get; set; }
        public GameLocationStateMachine NewLocation { get; set; }
    }
}