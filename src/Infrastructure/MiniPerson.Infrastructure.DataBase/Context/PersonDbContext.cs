using Microsoft.EntityFrameworkCore;
using MiniPerson.Domain.Entities;

namespace MiniPerson.Infrastructure.DataBase.Context
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
        : base(options)
        {

        }
        public DbSet<Person> Persons => Set<Person>();
    }
}
