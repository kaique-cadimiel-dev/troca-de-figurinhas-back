using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrocaDeFigurinhas.Interfaces;
using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpPost]
    public async Task<ActionResult<Report>> CreateReport(Report report)
    {
        var createdReport = await _reportService.CreateReportAsync(report);
        return CreatedAtRoute(null, new { id = createdReport.Id }, createdReport);
    }

    [HttpGet("spot/{spotId}")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<Report>>> GetReportsBySpot(Guid spotId)
    {
        var reports = await _reportService.GetReportsBySpotIdAsync(spotId);
        return Ok(reports);
    }
}
