using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Interfaces;

public interface ITradeSpotService
{
    Task<TradeSpot?> GetTradeSpotByIdAsync(Guid id);
    Task<IEnumerable<TradeSpot>> GetAllActiveTradeSpotsAsync();
    Task<TradeSpot> CreateTradeSpotAsync(TradeSpot spot);
}
