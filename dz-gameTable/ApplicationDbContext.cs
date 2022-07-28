using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_gameTable
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Studio> studios { get; set; }
        public DbSet<Models.Game> Games { get; set; }

        private string sqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karas\source\repos\dz-gameTable\dz-gameTable\Database1.mdf;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(sqlConnectionString);
        }
    }
}
