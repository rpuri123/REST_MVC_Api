using System.Collections.Generic;
using Commander.Model;

namespace Commander.Data
{
    // creating interface to use letter, it is just out line
    public interface ICommanderRepo
    {
        //naming the method but do not know how to implement.
        bool SaveChange();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}