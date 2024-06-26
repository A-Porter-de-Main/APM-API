using APMApi.Models.Database.RequestModels;
using APMApi.Models.Database.SkillModels;
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
    private readonly List<Status> _statuses = new();
    private readonly List<ResponseStatus> _responseStatuses = new();
    private readonly List<Skill> _skills = new();
    
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
                Phone = "060000000000",
                Password = BCrypt.Net.BCrypt.HashPassword("motDePasse", 5),
                RoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            }
        });
        _modelBuilder.Entity<User>().HasData(_users);
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
    
    private void GenerateStatuses()
    {
        _statuses.AddRange(new List<Status>
        {
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "open"
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "closed"
            }
        });
        
        _modelBuilder.Entity<Status>().HasData(_statuses);
    }

    private void GenerateResponseStatuses()
    {
        _responseStatuses.AddRange(new List<ResponseStatus>
        {
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "pending"
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "accepted"
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "rejected"
            }
        });
        
        _modelBuilder.Entity<ResponseStatus>().HasData(_responseStatuses);
    }
    
    private void GenerateSkills()
    {
        _skills.AddRange(new List<Skill>
        {
            // catégories parents
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Jardinage",
                Description = "S'occuper des plantes et des fleurs, de la pelouse, des arbres et des arbustes."
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Ménage",
                Description = "Nettoyer les pièces de la maison, les meubles, les sols, les vitres, les sanitaires."
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "Cuisine",
                Description = "Préparer des repas, des plats, des desserts, des boissons."
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Name = "Bricolage",
                Description = "Réparer, construire, installer, aménager, décorer."
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Name = "Informatique",
                Description = "Utiliser un ordinateur, un smartphone, une tablette, un logiciel, un site web."
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Name = "Couture",
                Description = "Coudre, tricoter, broder, raccommoder, repriser, customiser."
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                Name = "Peinture",
                Description = "Peindre les murs, les plafonds, les portes, les fenêtres, les meubles."
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                Name = "Baby-sitting",
                Description = "Garder des enfants, les accompagner, les divertir, les nourrir, les coucher."
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                Name = "Pet-sitting",
                Description = "Garder des animaux, les nourrir, les promener, les laver, les câliner."
            },
            
            // catégories enfants
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                Name = "Tonte de pelouse",
                Description = "Couper l'herbe de la pelouse à la tondeuse.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                Name = "Taille de haie",
                Description = "Tailler les arbustes et les haies à la cisaille.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                Name = "Plantation de fleurs",
                Description = "Planter des fleurs dans des pots ou en pleine terre.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                Name = "Nettoyage de vitres",
                Description = "Nettoyer les vitres des fenêtres et des portes.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                Name = "Nettoyage de sols",
                Description = "Nettoyer les sols des pièces de la maison.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000002")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                Name = "Préparation de repas",
                Description = "Préparer des repas équilibrés et savoureux.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000003")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                Name = "Réparation de meubles",
                Description = "Réparer les meubles cassés ou abîmés.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000004")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                Name = "Installation de meubles",
                Description = "Installer des meubles neufs ou d'occasion.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000004")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                Name = "Utilisation d'un ordinateur",
                Description = "Utiliser un ordinateur pour naviguer sur internet, envoyer des emails, rédiger des documents.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000005")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                Name = "Utilisation d'un smartphone",
                Description = "Utiliser un smartphone pour téléphoner, envoyer des messages, prendre des photos.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000005")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                Name = "Utilisation d'une tablette",
                Description = "Utiliser une tablette pour lire des livres, regarder des vidéos, jouer à des jeux.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000005")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000021"),
                Name = "Utilisation d'un logiciel",
                Description = "Utiliser un logiciel pour réaliser des tâches spécifiques.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000005")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                Name = "Utilisation d'un site web",
                Description = "Utiliser un site web pour consulter des informations, effectuer des achats, regarder des vidéos.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000005")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000023"),
                Name = "Couture à la main",
                Description = "Coudre des boutons, des ourlets, des déchirures à la main.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000006")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000024"),
                Name = "Couture à la machine",
                Description = "Coudre des vêtements, des accessoires, des objets à la machine.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000006")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000025"),
                Name = "Peinture de murs",
                Description = "Peindre les murs d'une pièce avec une peinture de couleur.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000007")
            },
            new()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000026"),
                Name = "Peinture de meubles",
                Description = "Peindre les meubles en bois, en métal, en plastique.",
                ParentId = Guid.Parse("00000000-0000-0000-0000-000000000007")
            }
        });
        
        _modelBuilder.Entity<Skill>().HasData(_skills);
    }

    public void Seed()
    {
        GenerateRoles();
        GenerateUsers();
        GenerateStatuses();
        GenerateResponseStatuses();
        GenerateSkills();
    }

    #endregion
}