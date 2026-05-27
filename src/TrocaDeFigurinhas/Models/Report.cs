namespace TrocaDeFigurinhas.Models;

public class Report
{
    public Guid Id { get; set; }
    public Guid SpotId { get; set; }
    public Guid UserId { get; set; }
    public string Reason { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
