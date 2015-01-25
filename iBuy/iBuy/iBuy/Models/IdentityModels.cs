using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace iBuy.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Announce> Announces { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name) : base(name) { }

        public string Description { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public DbSet<Announce> Announces { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
    //DropCreateDatabaseAlways
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // be ware that it should login the first time to generate admin then test data can be added
            InitializeIdentityForEf(context);

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            const string name = "admin@admin.com";

            // create address test data
            var addresses = new List<Address>()
                        {
                            new Address {City = "Hellemmes-Lille", PostalCode = 59260},
                            new Address {City = "Caudry", PostalCode = 59540},
                            new Address {City = "Paris",PostalCode = 75001},
                            new Address {City = "Lille",PostalCode = 59000},
                            new Address {City = "Villeneuve D'ascq",PostalCode = 59650}
            
            
            
                        };
            addresses.ForEach(a => context.Addresses.Add(a));
            context.SaveChanges();

            // create category test data
            var categories = new List<Category>()
                        {
                            new Category {Name = "Musice"},
                            new Category {Name = "Home"},
                        };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            // create announce test data
            var announces = new List<Announce>()
                        {
                            new Announce
                            {
                                Title = "Dj Animateur Pro Nord Pas-de-Calais",
                                Address = addresses[1],
                                Price = 200,
                                Description = @"bonjour,
            
            je vous propose mes services pour l'animation de :
            
            Mariage 400 € à 600€ (en fonction de vos besoins, option karaoké gratuite pour cette animation).
            Je propose également mes services pour les mariages et baptêmes algériens et marocains (chaabi, algérois, staifi, chaoui, kabyle, rai, alaoui, chaabi marocain, chleuh, imazighen, rif, reggada...)
            
            Anniversaire 200€ à 300€
            Baptême 200€ à 300€
            Evènement d'entreprise : 350€ à 600€
            Association 250 €à 350€
            Soirées privées 250 € à 600€
            º Option karaoké pendant animation 60€
            Soirée karaoké avec vidéoprojecteur et écran 150€
            Soirée karaoké + dancing 250€
            
            Je me déplace dans toute la région Nord Pas-de-Calais et Belgique
            
            Je dispose d'un matériel professionnel qui me permet de m'adapter à tout type d'environnement et taille de salle.
            
            Je mets à votre disposition tout mon savoir faire pour vous assurer un service de qualité et une soirée réussie.
            
            J'assure le mix pour:
            funk - disco- house- oriental -musique du monde et garantie un mix de qualité et fluide.
            
            Contactez-moi pour discuter de votre projet et vous établir un devis en fonction de vos besoins.
            Rendez vous gratuit sans engagement pour valider votre projet.
            
            Déclaration Urssaf et signature contrat avec acompte pour la réservation
            Possibilité location vidéoprojecteur BENQ",
                                Isprof = false,
                                User = userManager.FindByName(name),
                                Category = categories[1],
                                Date = DateTime.Now,
                                Type = 0
                            },
                            new Announce
                            {
                                Title = "Lecteur Dvd Philips",
                                Address = addresses[2],
                                Price = 35,
                                Description = @" Lecteur DVD Philips lit les divx ultra plat.
            Largeur 23 cm - Longueur 36 cm - Epaisseur 4 cm
            Excellent état
            
            Uniquement par téléphone",
                                Isprof = false,
                                User = userManager.FindByName(name),
                                Category = categories[1],
                                Date = DateTime.Now,
                                Type = 0
                            }
                        };
            announces.ForEach(a => context.Announces.Add(a));
            context.SaveChanges();

            base.Seed(context);
        }

        public static void InitializeIdentityForEf(ApplicationDbContext context)
        {
            var userManager = HttpContext
                .Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            var roleManager = HttpContext.Current
                .GetOwinContext()
                .Get<ApplicationRoleManager>();

            const string name = "admin@admin.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);

            if (role == null)
            {
                role = new ApplicationRole(roleName);
                var roleresult = roleManager.Create(role);
                context.SaveChanges();
            }

            var user = userManager.FindByName(name);

            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
                context.SaveChanges();
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);

            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
                context.SaveChanges();
            }

        }
    }
}