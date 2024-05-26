using Microsoft.EntityFrameworkCore;
using PointsOfInterest.Domain.Entities;

namespace PointsOfInterest.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
    }
}
