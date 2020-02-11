using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game.Player.Commands
{
    // Empty interface because the command class is using a generic type and i need to store the commands in a list.
    public interface ICommand { }

    [Serializable]
    public abstract class Command<TModel>: ICommand
    {
        public abstract bool Execute(TModel model);
        public virtual void Undo() { }
        public TModel Model;
    }
}