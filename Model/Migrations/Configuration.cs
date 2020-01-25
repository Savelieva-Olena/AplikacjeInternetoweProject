namespace Model.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Model.AppDbContext context)
        {
            if (!context.Categories.Any(x => x.Name == "Elektronika"))
            {
                context.Categories.Add(
                    new Entities.Category()
                    {
                        Name = "Elektronika"
                    });
                context.SaveChanges();
            }

            if (!context.Products.Any(x => x.Name == "Tablet"))
            {
                var categoryId = context.Categories.Where(x => x.Name == "Elektronika").Select(x => x.Id).First();
                context.Products.Add(
                    new Entities.Product()
                    {
                        Name = "Tablet",
                        Price = 1500,
                        CategoryId = categoryId

                    });
                context.SaveChanges();
            }

          

        }
    }
}
