using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APMApi.Models.Database;

[Table("Pictures")]
public class Picture
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("path")] [MaxLength(250)] public string Path { get; set; } = null!;

    [Column("description")]
    [MaxLength(250)]
    public string? Description { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }
}