using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Helpers;

public class DataSeeder
{
    #region Fields
    
    private readonly ModelBuilder _modelBuilder;
    private List<User> _users = new();
    
    #endregion
    
    #region Constructor
    
    public DataSeeder(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }
    
    #endregion
    
    #region Methods
    
    private void GenerateUsers()
    {
        for (var i = 0; i < 10; i++)
        {
            var user = new User
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _users.Add(user);
        }
        _modelBuilder.Entity<User>().HasData(_users);
    }
    
    public void Seed()
    {
        GenerateUsers();
    }
    
    #endregion
}