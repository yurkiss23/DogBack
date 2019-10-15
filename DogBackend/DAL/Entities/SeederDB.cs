using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBackend.DAL.Entities
{
    public class SeederDB
    {
        private static void SeedDogs(EFDbContext context)
        {
            string breedName = "Доворняга";
            if (context.Breeds.SingleOrDefault(d => d.Name == breedName) == null)
            {
                DbBreed breed = new DbBreed
                {
                    Name = breedName,
                    Image = "https://fb.ru/misc/i/thumb/a/1/3/5/3/2/6/9/1353269.jpg",
                    IsShow = true
                };
                context.Breeds.Add(breed);
                context.SaveChanges();
            }
            breedName = "Хаскі";
            if (context.Breeds.SingleOrDefault(d => d.Name == breedName) == null)
            {
                DbBreed breed = new DbBreed
                {
                    Name = breedName,
                    Image = "https://i.ytimg.com/vi/l5SEdPNhid0/hqdefault.jpg",
                    IsShow = true
                };
                context.Breeds.Add(breed);
                context.SaveChanges();
            }

            string name = "Шарік лизак";
            if (context.Dogs.SingleOrDefault(d => d.Name == name) == null)
            {
                DbDog dog = new DbDog
                {
                    Name = name,
                    Image = "https://85.img.avito.st/640x480/5408090485.jpg",
                    BreedId = context.Breeds.SingleOrDefault(b => b.Name == "Хаскі").Id
                };
                context.Dogs.Add(dog);
                context.SaveChanges();
            }

            name = "Бім до ноги прилип";
            if (context.Dogs.SingleOrDefault(d => d.Name == name) == null)
            {
                DbDog dog = new DbDog
                {
                    Name = name,
                    Image = "https://images.ua.prom.st/1605725118_w640_h640_kopilka-sobaka-sharik.jpg",
                    BreedId = context.Breeds.SingleOrDefault(b => b.Name == "Доворняга").Id
                };
                context.Dogs.Add(dog);
                context.SaveChanges();
            }
        }
        public static void SeedData(IServiceProvider services, 
            IHostingEnvironment env, 
            IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                SeedDogs(context);
            }
        }
    }
}
