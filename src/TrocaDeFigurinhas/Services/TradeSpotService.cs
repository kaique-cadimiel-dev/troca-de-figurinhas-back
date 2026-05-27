using TrocaDeFigurinhas.Interfaces;
using TrocaDeFigurinhas.Models;
using TrocaDeFigurinhas.Enums;

namespace TrocaDeFigurinhas.Services;

public class TradeSpotService : ITradeSpotService
{
    private readonly ITradeSpotRepository _tradeSpotRepository;

    public TradeSpotService(ITradeSpotRepository tradeSpotRepository)
    {
        _tradeSpotRepository = tradeSpotRepository;
    }

    public async Task<TradeSpot> CreateTradeSpotAsync(TradeSpot spot)
    {
        if (string.IsNullOrWhiteSpace(spot.Name))
        {
            throw new ArgumentException("Name cannot be empty");
        }

        spot.Id = Guid.NewGuid();
        spot.CreatedAt = DateTime.UtcNow;
        spot.Status = TradeSpotStatus.Active;
        
        await _tradeSpotRepository.AddAsync(spot);
        return spot;
    }

    public async Task<IEnumerable<TradeSpot>> GetAllActiveTradeSpotsAsync()
    {
        return await _tradeSpotRepository.GetAllActiveAsync();
    }

    public async Task<TradeSpot?> GetTradeSpotByIdAsync(Guid id)
    {
        return await _tradeSpotRepository.GetByIdAsync(id);
    }
}
