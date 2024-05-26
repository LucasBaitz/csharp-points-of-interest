using PointsOfInterest.Domain.Entities;
using System.Linq.Expressions;

namespace PointsOfInterest.Domain.Core.Intefaces
{
    public interface IPointOfInterestRepository
    {
        Task<PointOfInterest> Add(PointOfInterest poi);
        Task<PointOfInterest?> GetById(Guid id);
        Task<IEnumerable<PointOfInterest>> GetAllWhere(Expression<Func<PointOfInterest, bool>> predicate);
        Task Delete(PointOfInterest pointOfInterest);
    }
}
