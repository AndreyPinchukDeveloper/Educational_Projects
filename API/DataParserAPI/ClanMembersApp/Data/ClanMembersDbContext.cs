using ClanMembersApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanMembersApp.Data
{
    public class ClanMembersDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}BaseLocalDB.dv");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
