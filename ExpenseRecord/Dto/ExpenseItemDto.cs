using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseRecord.Dto;

public class ExpenseItemDto

{
    [Column("id")]
    public string? Id { get; set; }

    [Column("description")]
    [MaxLength(50)]
    public string? Description { get; set; }

    [Column("type")]
    [MaxLength(50)]
    public string? Type { get; set; }

    [Column("amount")]
    [Required]
    public double Amount { get; set; }

    [Column("date")]
    public DateOnly? Date { get; set; }
}