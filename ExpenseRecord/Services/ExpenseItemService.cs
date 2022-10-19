using ExpenseRecord.Dto;
using Microsoft.EntityFrameworkCore;

namespace ExpenseRecord.Services
{
    public class ExpenseItemService : IExpenseItemService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ExpenseItemService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<string> CreateAsync(ExpenseItemDto expenseItemDto)
        {
            var id = Guid.NewGuid().ToString();
            expenseItemDto.Id = id;

            _applicationDbContext.ExpenseList.Add(expenseItemDto);
            await _applicationDbContext.SaveChangesAsync();
            return id;
        }

        public async Task DeleteAsync(string id)
        {
            var expenseItem = await GetById(id);
            _applicationDbContext.ExpenseList.Remove(expenseItem);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<ExpenseItemDto>> GetAllAsync()
        {

           var allExpenses = await _applicationDbContext.ExpenseList.ToListAsync();

           return allExpenses;
        }

        public async Task<ExpenseItemDto> GetById(string id)
        {
            var expenseItem = await _applicationDbContext.ExpenseList.FindAsync(id);

            if (expenseItem == null) throw new Exception("Item not found");
            _applicationDbContext.Entry(expenseItem).State = EntityState.Detached;
            return expenseItem;
        }

        public async Task UpdateAsync(string id, ExpenseItemDto expenseItemUpdateDto)
        {
            await GetById(id);
            _applicationDbContext.ExpenseList.Update(expenseItemUpdateDto);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}

