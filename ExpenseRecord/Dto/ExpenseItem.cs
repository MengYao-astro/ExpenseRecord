using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseRecord.Dto;

public class ExpenseItem
{
    [Column("description")]
    [Required]
    [MaxLength(50)]
    public string Description { get; set; }

    [Column("type")]
    [Required]
    [MaxLength(50)]
    public string Type { get; set; }

    [Column("amount")]
    [Required]
    public double Amount { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; } = new DateOnly(0,0,0);
}