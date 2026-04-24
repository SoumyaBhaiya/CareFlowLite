using CareFlowLite.Data;
using CareFlowLite.DTOs;
using CareFlowLite.Enums;
using CareFlowLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CareFlowLite.Controllers;

[ApiController]
[Route("api/incidents")]
public class IncidentController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public IncidentController(AppDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> Create(IncidentDto dto)
    {
        var incident = new Incident
        {
            PatientId = dto.PatientId,
            Severity = dto.Severity,
            Title = dto.Title,
            Description = dto.Description
        };
        _context.Incidents.Add(incident);
        await _context.SaveChangesAsync();

        return Ok(incident);
    }
    [HttpGet]

    public async Task<IActionResult> Get([FromQuery] Severity? severity)
    {
        var query = _context.Incidents.AsQueryable();

        if(severity != null)
        query = query.Where(i=> i.Severity == severity);

        return Ok(await query.ToListAsync());
    }
    
    [HttpPatch("{id}/resolve")]
    public async Task<IActionResult> Resolve(int id)
    {
        var incident = await _context.Incidents.FindAsync(id);
        if (incident == null) return NotFound();

        incident.Status = IncidentStatus.Resolved;
        incident.ResolvedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return Ok(incident);
    }
    [HttpPost("{id}/rca")]
    public async Task<IActionResult> AddRCA(int id, RCADto dto)
    {
        var incident = await _context.Incidents.FindAsync(id);
        if (incident == null) return NotFound();
        
        var rca = new RCA
        {
            IncidentId = id,
            Why1 = dto.Why1,
            Why2 = dto.Why2,
            Why3 = dto.Why3,
            RootCause = dto.RootCause,
            FixApplied = dto.FixApplied
        };

        _context.RCAs.Add(rca);
        await _context.SaveChangesAsync();

        return Ok(rca);
    }
}