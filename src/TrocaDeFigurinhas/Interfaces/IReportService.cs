using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Interfaces;

public interface IReportService
{
    Task<Report> CreateReportAsync(Report report);
    Task<IEnumerable<Report>> GetReportsBySpotIdAsync(Guid spotId);
}
