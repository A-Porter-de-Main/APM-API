using APMApi.Context.Configurations.FeedbackConfigurations;
using APMApi.Context.Configurations.RequestConfigurations;
using APMApi.Context.Configurations.SkillConfigurations;
using APMApi.Context.Configurations.UserConfigurations;
using APMApi.Models.Database;
using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Context;

public class DataContext : DbContext
{
    #region Constructor

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    #endregion
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new PreferenceConfiguration());
        modelBuilder.ApplyConfiguration(new ChatConfiguration());
        
        
        modelBuilder.ApplyConfiguration(new RequestConfiguration());
        modelBuilder.ApplyConfiguration(new ResponseConfiguration());
        modelBuilder.ApplyConfiguration(new StatusConfiguration());
        modelBuilder.ApplyConfiguration(new ResponseStatusConfiguration());

        
        modelBuilder.ApplyConfiguration(new SkillConfiguration());
        modelBuilder.ApplyConfiguration(new ObjectConfiguration());
        modelBuilder.ApplyConfiguration(new ObjectCategoryConfiguration());
        
        
        modelBuilder.ApplyConfiguration(new FeedBackConfiguration());
        modelBuilder.ApplyConfiguration(new FeedBackApplicationConfiguration());
        modelBuilder.ApplyConfiguration(new IssueConfiguration());
        
        // var dataSeeder = new DataSeeder(modelBuilder);
        // dataSeeder.Seed();
    }

    /// <summary>
    ///     Users tables
    /// </summary>
    public required DbSet<User> Users { get; set; }

    public required DbSet<Address> Addresses { get; set; }
    public required DbSet<Role> Roles { get; set; }
    public required DbSet<Preference> Preferences { get; set; }

    /// <summary>
    ///     Requests tables
    /// </summary>
    public required DbSet<Request> Requests { get; set; }

    public required DbSet<Picture> Pictures { get; set; }
    public required DbSet<Response> Responses { get; set; }
    public required DbSet<Status> Statuses { get; set; }
    public required DbSet<ResponseStatus> ResponseStatuses { get; set; }

    /// <summary>
    ///     Categories tables
    /// </summary>
    public required DbSet<Skill> Skills { get; set; }

    public required DbSet<ObjectModel> Objects { get; set; }
    public required DbSet<ObjectCategory> Types { get; set; }

    /// <summary>
    ///     Chats tables
    /// </summary>
    public required DbSet<Chat> Chats { get; set; }

    /// <summary>
    ///     FeedBacks tables
    /// </summary>
    public required DbSet<FeedBackApplication> FeedBacksApplication { get; set; }

    public required DbSet<FeedBack> FeedBacks { get; set; }
    public required DbSet<Issue> Issues { get; set; }
}