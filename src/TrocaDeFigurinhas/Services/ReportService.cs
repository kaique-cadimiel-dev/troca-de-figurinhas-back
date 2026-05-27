using TrocaDeFigurinhas.Interfaces;
using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _reportRepository;

    public ReportService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<Report> CreateReportAsync(Report report)
    {
        report.Id = Guid.NewGuid();
        report.CreatedAt = DateTime.UtcNow;
        
        await _reportRepository.AddAsync(report);
        return report;
    }

    public async Task<IEnumerable<Report>> GetReportsBySpotIdAsync(Guid spotId)
    {
        return await _reportRepository.GetBySpotIdAsync(spotId);
    }
}
