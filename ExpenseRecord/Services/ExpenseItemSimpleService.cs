using ExpenseRecord.Dto;
using System;
using System.Collections.Generic;

namespace ExpenseRecord.Services
{
    public class ExpenseItemSimpleService : IExpenseItemService
    {
        private List<ExpenseItemDto> expenseList;

        public ExpenseItemSimpleService()
        {
            expenseList = new List<ExpenseItemDto>();
            
        }

        public async Task<string> CreateAsync(ExpenseItemDto expenseItemDto)
        {
            var id = Guid.NewGuid().ToString();
            expenseItemDto.Id = id;
            expenseList.Insert(0,expenseItemDto);
            return id;
        }
        public async Task DeleteAsync(string id)
        {
            expenseList.RemoveAll(e => e.Id == id);
        }

        public async Task<List<ExpenseItemDto>> GetAllAsync()
        {
            return expenseList;
        }

        public async Task<ExpenseItemDto> GetById(string id)
        {
            var expenseItem =  expenseList.FirstOrDefault(e => e.Id == id);
            if (expenseItem == null)
            {
                throw new Exception("Item Not Found");
            }
            else
            {
                return expenseItem;
            }
        }
        public async Task UpdateAsync(string id, ExpenseItemDto expenseItemUpdateDto)
        {
            var index = expenseList.FindIndex(e => e.Id == id);
            expenseList[index] = expenseItemUpdateDto;

        }
    }
}
