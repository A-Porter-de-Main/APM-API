using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Helpers;

public class DataSeeder
{
    #region Constructor

    public DataSeeder(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    #endregion

    #region Fields

    private readonly ModelBuilder _modelBuilder;
    private readonly List<User> _users = new();
    private readonly List<Role> _roles = new();

    #endregion

    #region Methods

    private void GenerateUsers()
    {
        _users.AddRange(new List<User>
        {
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                FirstName = "John",
                LastName = "Doe",
                PicturePath = "https://cours-informatique-gratuit.fr/wp-content/uploads/2014/05/administrateur.png",
                Email = "admin@apm.com",
                Password = BCrypt.Net.BCrypt.HashPassword("motDePasse", 5),
                RoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            }
        });
    }

    private void GenerateRoles()
    {
        _roles.AddRange(new List<Role>
        {
            new() {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "admin"
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "user"
            }
        });
        
        _modelBuilder.Entity<Role>().HasData(_roles);
    }

    public void Seed()
    {
        GenerateRoles();
        GenerateUsers();
    }

    #endregion
}