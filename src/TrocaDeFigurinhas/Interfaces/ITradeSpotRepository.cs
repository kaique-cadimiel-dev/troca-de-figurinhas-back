using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Interfaces;

public interface ITradeSpotRepository
{
    Task<TradeSpot?> GetByIdAsync(Guid id);
    Task<IEnumerable<TradeSpot>> GetAllActiveAsync();
    Task AddAsync(TradeSpot spot);
    Task UpdateAsync(TradeSpot spot);
}
