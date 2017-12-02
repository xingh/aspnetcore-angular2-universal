using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspCoreServer.Models;
using AspCoreServer;

namespace AspCoreServer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SpaDbContext context)
        {
            //context.Database.EnsureDeleted();
            //context.Database.Migrate();
            context.Database.EnsureCreated();

            //initialize users
            if (!context.User.Any())
            {
              var users = new User[]
              {
                new User(){Name = "Mark Pieszak"},
                new User(){Name = "Abrar Jahin"},
                new User(){Name = "hakonamatata"},
                new User(){Name = "LiverpoolOwen"},
                new User(){Name = "Ketrex"},
                new User(){Name = "markwhitfeld"},
                new User(){Name = "daveo1001"},
                new User(){Name = "paonath"},
                new User(){Name = "nalex095"},
                new User(){Name = "ORuban"},
                new User(){Name = "Gaulomatic"}
              };

              foreach (User s in users)
              {
                  context.User.Add(s);
              }
              context.SaveChanges();

            }

            if (context.Leaf.Any()){
              return;
            }

            var leaves = new Leaf[]
            {
              new Leaf(){ItemPath="http://www.anant.co", ItemName = "Anant"},
              new Leaf(){ItemPath="http://www.anant.co", ItemName = "Appleseed"},
              new Leaf(){ItemPath="http://www.anant.co", ItemName = "Konotree"},
              new Leaf(){ItemPath="http://www.anant.co", ItemName = "Asitchanges"},
              new Leaf(){ItemPath="http://www.anant.co", ItemName = "Qrisp"},
              new Leaf(){ItemPath="http://www.anant.co", ItemName = "TalkForChange"},
              new Leaf(){ItemPath="http://www.anant.co", ItemName = "XavierSingh"},
              new Leaf(){ItemPath="http://www.anant.co", ItemName = "Framework"},
              new Leaf(){ItemPath="http://www.anant.co", ItemName = "Graph"},
              new Leaf(){ItemPath="http://www.anant.co", ItemName = "Platform"},
              new Leaf(){ItemPath="http://www.anant.co", ItemName = "Network"}
            };

            foreach (Leaf l in leaves)
            {
                context.Leaf.Add(l);
            }
            context.SaveChanges();


        }
    }
}
