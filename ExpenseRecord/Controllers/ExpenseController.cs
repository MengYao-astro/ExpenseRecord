using ExpenseRecord.Dto;
using ExpenseRecord.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseRecord.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseItemService _expenseItemService;

    public ExpenseController(IExpenseItemService expenseItemService)
    {
        _expenseItemService = expenseItemService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateItemAsync(ExpenseItemDto expenseItemDto)
    {
        try
        {
            var id = await _expenseItemService.CreateAsync(expenseItemDto);
            return Created($"Expense/{id}", id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IActionResult> GetItemByIdAsync([FromRoute] string id)
    {
        try
        {
            var expenseItem = await _expenseItemService.GetById(id);
            return new ObjectResult(expenseItem);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItemsAsync()
    {
        var  expenseList = await _expenseItemService.GetAllAsync();
        return new ObjectResult(expenseList);
    }

    [HttpPut]
    [Route("{Id}")]
    public async Task<IActionResult> UpdateItemAsync([FromRoute] string id, [FromBody] ExpenseItemDto expenseItemDto)
    {
        try
        {
            await _expenseItemService.UpdateAsync(id, expenseItemDto);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> DeleteItemAsync([FromRoute] string id)
    {
        try
        {
            await _expenseItemService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

    }
}