using TrocaDeFigurinhas.Enums;

namespace TrocaDeFigurinhas.Models;

public class TradeSpot
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public float Lat { get; set; }
    public float Lng { get; set; }
    public string? Whatsapp { get; set; }
    public string? PhotoUrl { get; set; }
    public string[] Days { get; set; } = Array.Empty<string>();
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public TradeSpotStatus Status { get; set; }
    public Guid ReportedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}
