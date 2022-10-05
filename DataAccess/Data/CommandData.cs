using DataAccess.DBAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CommandData : ICommandData
    {
        private readonly ISQLDataAccess _db;

        public CommandData(ISQLDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<CommandModel>> GetCommands() =>
            _db.LoadData<CommandModel, dynamic>("dbo.spCommand_GetAll", new { });

        public async Task<CommandModel?> GetCommand(int Id)
        {
            var result = await _db.LoadData<CommandModel, dynamic>("dbo.spCommand_GetById", new { Id });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<CommandModel>> GetByFilter(string property, string value)
        {
            IEnumerable<CommandModel> result = new List<CommandModel>();

            switch (property)
            {
                case "Platform":
                    {
                        result = await _db.LoadData<CommandModel, dynamic>("dbo.spCommand_GetByPlatform", new { Platform = value });
                        break;
                    }
                case "CommandDesc":
                    {
                        result = await _db.LoadData<CommandModel, dynamic>("dbo.spCommand_GetByCommandDescription", new { Description = value });
                        break;
                    }
            }

            return result;
        }

        public async Task InsertCommand(CommandModel command) =>
            await _db.SaveData("dbo.spCommand_Insert", new { command.Platform, command.CommandDesc, command.Command });
        


        public Task UpdateCommand(CommandModel command) =>
            _db.SaveData("dbo.spCommand_Update", command);

        public Task DeleteCommand(int Id) =>
            _db.SaveData("dbo.spCommand_Delete", new { Id });
    }
}
