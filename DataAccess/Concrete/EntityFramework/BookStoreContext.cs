using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class BookStoreContext:DbContext
    {
        //Tablondaki books isimli tablona denk gelir diyoruz.
        public DbSet<Book> Books{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=BookStore;Trusted_Connection=true;");
        }
    }
}
