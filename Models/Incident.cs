using CareFlowLite.Enums;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.Extensions.Localization;

namespace CareFlowLite.Models;

public class Incident
{
    public int Id {get; set;}
    public int? PatientId {get; set;}

    public Severity Severity{get; set;}
    public string Title {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;

    public IncidentStatus Status {get; set;} = IncidentStatus.Open;

    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public DateTime? ResolvedAt {get; set;}

    public RCA? RCA {get; set;}

}