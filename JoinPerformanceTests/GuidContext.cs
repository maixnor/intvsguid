using System.Linq;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace JoinPerformanceTests
{
    public class GuidContext : DbContext
    {
        public DbSet<GuidPerson> People { get; set; } = default!;
        public DbSet<GuidEmail> Emails { get; set; } = default!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=Guid.db");
        }

        public void Seed()
        {
            var emails = new Faker<GuidEmail>().Rules((f, e) =>
            {
                e.Email = f.Internet.Email();
            }).Generate(10000).ToList();
            
            var people = new Faker<GuidPerson>().Rules((f, p) =>
            {
                var picked = f.Random.ListItems(emails);
                p.Emails.AddRange(picked);
            }).Generate(1000).ToList();
            
            Emails.AddRange(emails);
            People.AddRange(people);
            SaveChanges();
        }
    }
}