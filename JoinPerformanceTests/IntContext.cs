using System.Linq;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace JoinPerformanceTests
{
    public class IntContext : DbContext
    {
        public DbSet<IntPerson> People { get; set; } = default!;
        public DbSet<IntEmail> Emails { get; set; } = default!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=Int.db");
        }
        
        public void Seed()
        {
            var emails = new Faker<IntEmail>().Rules((f, e) =>
            {
                e.Email = f.Internet.Email();
            }).Generate(10000).ToList();
            var people = new Faker<IntPerson>().Rules((f, p) =>
            {
                p.Emails.AddRange(f.Random.ListItems(emails));
            }).Generate(1000).ToList();
            
            Emails.AddRange(emails);
            People.AddRange(people);
            SaveChanges();
        }
    }
}