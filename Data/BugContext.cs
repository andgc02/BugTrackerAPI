using Microsoft.EntityFrameworkCore;
using BugTrackerAPI.Models;

namespace BugTrackerAPI.Data
{
    // Database context for interacting with the Bug data model
    public class BugContext : DbContext
    {
        // Constructor that takes DbContextOptions to configure the context
        public BugContext(DbContextOptions<BugContext> options) : base(options)
        {
        }

        // Represents the Bugs table in the database
        public DbSet<Bug> Bugs { get; set; }
    }
}