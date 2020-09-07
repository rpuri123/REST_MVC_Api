using System.Collections.Generic;
using Commander.Model;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        //Test data
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=1, HowTo="Boil an egg", Line="Boil water", Plateform="Kettle and Pan"},
                new Command{Id=2, HowTo="Cut bread", Line="Get a knife", Plateform="Knife and chopping board"},
                new Command{Id=3, HowTo="Make cup of tea", Line="Place teabag in cup", Plateform="Kettle and cup"}
            };

            return commands;
        }
        
        

        public Command GetCommandById(int id)
        {
            return new Command{Id=1, HowTo="Boil an egg", Line="Boil water", Plateform="Kettle and Pan"};
        }

        public bool SaveChange()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }


}