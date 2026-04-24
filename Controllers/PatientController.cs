using CareFlowLite.Data;
using CareFlowLite.DTOs;
using CareFlowLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareFlowLite.Controllers;

[ApiController]
[Route("api/patients")]

public class PatientController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public PatientController(AppDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> Create(PatientDto dto)
    {
        var patient = new Patient
        {
            name = dto.Name,
            Age = dto.Age,
            Gender = dto.Gender
        };

        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();

        return Ok(patient);
    }

    [HttpGet]
    public async Task <IActionResult> GetAll()
    {
        return Ok(await _context.Patients.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        return patient == null ? NotFound() : Ok (patient);
    }
}