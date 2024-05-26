using Microsoft.EntityFrameworkCore;
using PointsOfInterest.Domain.Core.Intefaces;
using PointsOfInterest.Domain.Entities;
using PointsOfInterest.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace PointsOfInterest.Infrastructure.Repositories
{
    internal class PointOfInterestRepository : IPointOfInterestRepository
    {
        private readonly ApplicationDbContext _context;

        public PointOfInterestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PointOfInterest> Add(PointOfInterest poi)
        {
            var creationResult = await _context.AddAsync(poi);
            await _context.SaveChangesAsync();

            return creationResult.Entity;
        }

        public async Task Delete(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetAllWhere(Expression<Func<PointOfInterest, bool>> predicate)
        {
            return await _context.PointsOfInterest.ToListAsync();
        }

        public async Task<PointOfInterest?> GetById(Guid id)
        {
            return await _context.PointsOfInterest.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
