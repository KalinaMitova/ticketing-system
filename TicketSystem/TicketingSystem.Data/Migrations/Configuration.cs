namespace TicketingSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using TicketingSystem.Common;
    using TicketingSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<TicketingSystemDbContext>
    {
        private UserManager<User> userManager;
        private IRandomGenerator random;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomGenerator();
        }

        protected override void Seed(TicketingSystemDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context)) ;
            this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedCategoriesWithTicketsWithComments(context);
        }

        private void SeedUsers(TicketingSystemDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }
            for (int i = 0; i < 6; i++)
            {
                User user = new User
                {
                    Email = $"{this.random.RandomString(6, 10)}@{this.random.RandomString(6, 7)}.com",
                    UserName = this.random.RandomString(6, 16)
                };

                this.userManager.Create(user, "123456");
            }

            User adminUser = new User
            {
                Email = "admin@siet.com",
                UserName ="Administrator"
            };

            this.userManager.Create(adminUser, "admin123456");
            this.userManager.AddToRole(adminUser.Id, GlobalConstants.AdminRole);
        }

        private void SeedRoles(TicketingSystemDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdminRole));
            context.SaveChanges();
        }

        private void SeedCategoriesWithTicketsWithComments(TicketingSystemDbContext contex)
        {
            if (contex.Category.Any())
            {
                return; 
            }

            var users = contex.Users.Take(10).ToList(); 

            List<Image> images = this.GetSampleImage();

            for (int i = 0; i < 5; i++)
            {
                Category category = new Category
                {
                    Name = this.random.RandomString(5, 15)             
                };

                for (int j = 0; j < 10; j++)
                {
                    Ticket ticket = new Ticket
                    {
                        Author = users[this.random.RandomNumber(0, users.Count - 1)],
                        Image = images[this.random.RandomNumber(0,images.Count - 1)],
                        Title = this.random.RandomString(10, 50),
                        Description = this.random.RandomString(10, 20),
                        Priority = (PrioriryType)this.random.RandomNumber(0,2)                      
                    };

                    for (int k = 0; k < 5; k++)
                    {
                        Comment comment = new Comment
                        {
                            Author = users[this.random.RandomNumber(0, users.Count - 1)],
                            Content = this.random.RandomString(100, 250),
                        };

                        ticket.Comments.Add(comment);
                    }

                    category.Tickets.Add(ticket);
                }

                contex.Category.Add(category);
                contex.SaveChanges();
            }
        }
        private List<Image> GetSampleImage()
        {
            List<Image> images = new List<Image>();

            string directory = AssemblyHelpers.GetDirectoryFoeAssembly(Assembly.GetExecutingAssembly());
            
            var fileCat = File.ReadAllBytes(directory + "/Content/images/crazyCat.jpg");
            var fileHedgehog = File.ReadAllBytes(directory + "/Content/images/hedgehog.jpg");

            Image catImg = new Image
            {
                Content = fileCat,
                FileExtension = "jpg"
            };

            Image HedgehogImg = new Image
            {
                Content = fileHedgehog,
                FileExtension = "jpg"
            };

            images.Add(catImg);
            images.Add(HedgehogImg);

            return images;
        }

    }
}
