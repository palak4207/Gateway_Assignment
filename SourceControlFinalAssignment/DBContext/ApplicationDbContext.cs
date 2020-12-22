using Microsoft.EntityFrameworkCore;
using SourceControlFinalAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SourceControlFinalAssignment.DBContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
