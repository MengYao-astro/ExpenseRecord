using ExpenseRecord.Dto;

namespace ExpenseRecord.Services
{
    public interface IExpenseItemService
    {
        Task<string> CreateAsync(ExpenseItemDto expenseItemDto);
        Task UpdateAsync(string id, ExpenseItemDto expenseItemDto);
        Task DeleteAsync(string id);
        Task<ExpenseItemDto> GetById(string id);

        Task<List<ExpenseItemDto>> GetAllAsync();

    }
}
