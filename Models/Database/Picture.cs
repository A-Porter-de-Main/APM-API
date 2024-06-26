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

    [Column("name")] [MaxLength(50)] public string Name { get; set; } = null!;
    
    [Column("path")] [MaxLength(250)] public string Path { get; set; } = null!;

    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }
}