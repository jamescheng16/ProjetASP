using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using iBuy.Models;

namespace iBuy.DAL
{
    public class AnnounceInitializer: System.Data.Entity. DropCreateDatabaseIfModelChanges<AnnounceContext>
    {
        protected override void Seed(AnnounceContext context)
        {
            // create address test data
            var addresses = new List<Address>()
            {
                new Address {City = "Hellemmes-Lille", PostalCode = 59260},
                new Address {City = "Caudry", PostalCode = 59540},
                new Address {City = "Paris",PostalCode = 75001}

            };
            addresses.ForEach(a => context.Addresses.Add(a));
            context.SaveChanges();

            // create user test data
            var users = new List<User>()
            {
                new User {Mail = "test1@test.com", Password = "1234", PhoneNumber = 12345678},
                new User {Mail = "test2@test.com", Password = "1234", PhoneNumber = 12345678},
                new User {Mail = "test3@test.com", Password = "1234", PhoneNumber = 12345678},
                new User {Mail = "test4@test.com", Password = "1234", PhoneNumber = 12345678},
                new User {Mail = "admin@test.com", Password = "1234", PhoneNumber = 12345678},
            };
            users.ForEach(u => context.Users.Add(u));
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
                    User = users[1],
                    Category = categories[1],
                    Date = DateTime.Now,
                    Type = 0
                },
                new Announce
                {
                    Title = "Lecteur Dvd Philips",
                    Address = addresses[2],
                    Price = 25,
                    Description = @" Lecteur DVD Philips lit les divx ultra plat.
Largeur 23 cm - Longueur 36 cm - Epaisseur 4 cm
Excellent état

Uniquement par téléphone",
                    Isprof = false,
                    User = users[2],
                    Category = categories[1],
                    Date = DateTime.Now,
                    Type = 0
                }
            };
            announces.ForEach(a => context.Announces.Add(a));
            context.SaveChanges();
        }
    }
}