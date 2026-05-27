using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Interfaces;

public interface IReportRepository
{
    Task<Report?> GetByIdAsync(Guid id);
    Task<IEnumerable<Report>> GetBySpotIdAsync(Guid spotId);
    Task AddAsync(Report report);
}
