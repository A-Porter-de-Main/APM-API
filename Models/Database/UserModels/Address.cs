using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.UserDto.AddressDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.UserModels;

[Table("Addresses")]
public class Address : IBaseModel<Address, AddressCreateDto, AddressUpdateDto>
{
    #region Fields

    
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("street")] [MaxLength(50)] public string Street { get; set; } = null!;

    [Column("city")] [MaxLength(50)] public string City { get; set; } = null!;

    [Column("zip_code")] [MaxLength(50)] public string ZipCode { get; set; } = null!;

    [Column("latitude")] [MaxLength(50)] public string Latitude { get; set; } = null!;

    [Column("longitude")] [MaxLength(50)] public string Longitude { get; set; } = null!;
    
    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    #endregion

    #region Relations

    [Column("user_id")] public Guid? UserId { get; set; }
    [ForeignKey(nameof(UserId))] public User? User { get; set; }

    #endregion

    #region Methods
    
    public static Address Create(AddressCreateDto createDto)
    {
        return new Address
        {
            Street = createDto.Street,
            City = createDto.City,
            ZipCode = createDto.ZipCode,
            Latitude = createDto.Latitude,
            Longitude = createDto.Longitude,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public Address Update(AddressUpdateDto updateDto)
    {
        Street = updateDto.Street;
        City = updateDto.City;
        ZipCode = updateDto.ZipCode;
        Latitude = updateDto.Latitude;
        Longitude = updateDto.Longitude;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<Address> GetDbSet(DataContext context)
    {
        return context.Addresses;
    }

    #endregion
}