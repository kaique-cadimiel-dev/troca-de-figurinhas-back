using Microsoft.EntityFrameworkCore;
using TrocaDeFigurinhas.Data;
using TrocaDeFigurinhas.Interfaces;
using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly AppDbContext _context;

    public ReportRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Report?> GetByIdAsync(Guid id)
    {
        return await _context.Reports.FindAsync(id);
    }

    public async Task<IEnumerable<Report>> GetBySpotIdAsync(Guid spotId)
    {
        return await _context.Reports
            .Where(r => r.SpotId == spotId)
            .ToListAsync();
    }

    public async Task AddAsync(Report report)
    {
        await _context.Reports.AddAsync(report);
        await _context.SaveChangesAsync();
    }
}
