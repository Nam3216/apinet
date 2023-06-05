using Microsoft.EntityFrameworkCore;
using WebApplication1.modelos;

namespace WebApplication1.Store
{
    public class ApplicationDbContext:DbContext//hereda clase DbContext, para eso importar microsoft entity frameworkCore
    {//crear constructor ctor doble tab
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //DBContextOptions mismo tipo que ApplicationDbContext, y despues que la base desde dond se herada, le mandamos toda la config en options por medio de inyecion dependencia
        {
        }

        public DbSet<ModelClass> ModelClasses { get; set; }//le pongo nombre ModelClasses, asi se va a guardar la lista en databas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelClass>().HasData(
                new ModelClass()
                {
                    id = 1,
                    name = "casa1",
                    description = "first casa",
                    quantity = 0,
                    img = "https://www.puntodebreak.com/files/styles/eht/public/medvedev-prensa-seyboth-wild.jpg?itok=l74U9Mki",
                    price = 0,
                },
                 new ModelClass()
                 {
                     id = 2,
                     name = "casa2",
                     description = "secon casa",
                     quantity = 0,
                     img = "https://www.elgrafico.com.ar/media/cache/pub_news_details_large/media/i/c7/93/c793620737acdccd2d5b00b4d0f0483f613b22b6.jpg",
                     price = 0,
                 },
                  new ModelClass()
                  {
                      id = 3,
                      name = "casa3",
                      description = "third casa",
                      quantity = 0,
                      img = "https://imgresizer.eurosport.com/unsafe/1200x0/filters:format(webp):focal(1312x271:1314x269)/origin-imgresizer.eurosport.com/2023/03/22/3667442-74657768-2560-1440.jpg",
                      price = 0,
                  }
                  );
        }
    }
}
