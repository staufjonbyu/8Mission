using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8Mission.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    Category_Name = "Home"
                },
                new Category
                {
                    CategoryID = 2,
                    Category_Name = "School"
                },
                new Category
                {
                    CategoryID = 3,
                    Category_Name = "Work"
                },
                new Category
                {
                    CategoryID = 4,
                    Category_Name = "Church"
                }
                );

            mb.Entity<Tasks>().HasData(
                new Tasks
                {
                    TaskID = 1,
                    Task_Name = "Crises",
                    Due_Date = "2005-12-01",
                    Quadrant = 1,
                    Completed = false,
                    CategoryID = 1
                },
                new Tasks
                {
                    TaskID = 2,
                    Task_Name = "Relationship Building",
                    Due_Date = "2005-12-01",
                    Quadrant = 2,
                    Completed = false,
                    CategoryID = 1
                },
                new Tasks
                {
                    TaskID = 3,
                    Task_Name = "Interruptions",
                    Due_Date = "2005-12-01",
                    Quadrant = 3,
                    Completed = false,
                    CategoryID = 1
                },
                new Tasks
                {
                    TaskID = 4,
                    Task_Name = "Busy Work",
                    Due_Date = "2005-12-01",
                    Quadrant = 4,
                    Completed = false,
                    CategoryID = 1
                }
                );
        }
    }
}
