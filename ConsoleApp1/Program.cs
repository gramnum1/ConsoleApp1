using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Beginning");
            using(var context = new MusicContext())
            {



                var count = context.Albums.Count();
                Console.WriteLine("Albums Count Before Insert: " + count);
                
                context.Albums.Add(new Album() { Price = 9.99m, Title = "Another" });
                context.SaveChanges();
                count = context.Albums.Count();
                Console.WriteLine("Albums Count After Insert: " + count);

                var albums = context.Albums.Where(o => o.Title.Contains("w"));
                count = albums.Count();
                Console.WriteLine("Albums With W: " + count);
                Console.ReadLine();

            }
        }
    }

    

    public class MusicContext : DbContext
    {
        
        
        public DbSet<Album> Albums { get; set; }
    }

    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
