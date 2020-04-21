using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace VJ.MyAirport.EF
{
    public class MyAirportContext : DbContext
    {
        public DbSet<Vol> Vols { get; set; }
        public DbSet<Bagage> Bagages { get; set; }

        public MyAirportContext(DbContextOptions<MyAirportContext> options) : base(options)
        {
        }

        public MyAirportContext()
        {
        }

        /*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True");
                }*/

    }
}
