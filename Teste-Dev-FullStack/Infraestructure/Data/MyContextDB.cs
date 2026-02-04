using Microsoft.EntityFrameworkCore;
using Teste_Dev_FullStack.Domain.Entities;

namespace Teste_Dev_FullStack.Infraestructure.Data
{
    public class MyContextDB: DbContext
    {
        public MyContextDB(DbContextOptions<MyContextDB> options) : base(options)
        {
        }
        public DbSet<Person> PersonsSet { get; set; }
        public DbSet<Transection> TransectionsSet { get; set; }
        public DbSet<Category> CategoriesSet { get; set; }
    }
}
