using DataAccess.Models;

namespace DataAccess.Data
{
    public interface ICommandData
    {
        Task DeleteCommand(int Id);
        Task<IEnumerable<CommandModel>> GetByFilter(string property, string value);
        Task<IEnumerable<CommandModel>> GetCommands();
        Task<CommandModel?> GetCommand(int Id);
        Task InsertCommand(CommandModel command);
        Task UpdateCommand(CommandModel command);
    }
}