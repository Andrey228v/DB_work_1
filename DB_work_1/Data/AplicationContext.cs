using DB_work_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_work_1.Data
{

    //https://www.youtube.com/watch?v=S9HrLdSrVho
    // https://www.youtube.com/c/RuslanShishmarev/videos
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Deportament> Deportaments { get; set; }


        public ApplicationContext()
        {
            // Если базы данных нет, то она создастся 
            Database.EnsureCreated();
        }


        // Подключение
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ManageStaffDBAppDB;Trusted_Connection=True;");
        }

    }
}
