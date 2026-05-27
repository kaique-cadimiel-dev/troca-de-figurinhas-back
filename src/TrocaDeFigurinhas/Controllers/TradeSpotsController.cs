using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrocaDeFigurinhas.Interfaces;
using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TradeSpotsController : ControllerBase
{
    private readonly ITradeSpotService _tradeSpotService;

    public TradeSpotsController(ITradeSpotService tradeSpotService)
    {
        _tradeSpotService = tradeSpotService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<TradeSpot>>> GetTradeSpots()
    {
        var spots = await _tradeSpotService.GetAllActiveTradeSpotsAsync();
        return Ok(spots);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<TradeSpot>> GetTradeSpot(Guid id)
    {
        var spot = await _tradeSpotService.GetTradeSpotByIdAsync(id);
        if (spot == null)
        {
            return NotFound();
        }
        return Ok(spot);
    }

    [HttpPost]
    public async Task<ActionResult<TradeSpot>> CreateTradeSpot(TradeSpot spot)
    {
        var createdSpot = await _tradeSpotService.CreateTradeSpotAsync(spot);
        return CreatedAtAction(nameof(GetTradeSpot), new { id = createdSpot.Id }, createdSpot);
    }
}
