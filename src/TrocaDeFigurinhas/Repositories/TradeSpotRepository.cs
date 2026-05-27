using Microsoft.EntityFrameworkCore;
using TrocaDeFigurinhas.Data;
using TrocaDeFigurinhas.Interfaces;
using TrocaDeFigurinhas.Models;
using TrocaDeFigurinhas.Enums;

namespace TrocaDeFigurinhas.Repositories;

public class TradeSpotRepository : ITradeSpotRepository
{
    private readonly AppDbContext _context;

    public TradeSpotRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TradeSpot?> GetByIdAsync(Guid id)
    {
        return await _context.TradeSpots.FindAsync(id);
    }

    public async Task<IEnumerable<TradeSpot>> GetAllActiveAsync()
    {
        return await _context.TradeSpots
            .Where(s => s.Status == TradeSpotStatus.Active)
            .ToListAsync();
    }

    public async Task AddAsync(TradeSpot spot)
    {
        await _context.TradeSpots.AddAsync(spot);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TradeSpot spot)
    {
        _context.TradeSpots.Update(spot);
        await _context.SaveChangesAsync();
    }
}
