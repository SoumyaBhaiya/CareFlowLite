using CareFlowLite.Enums;

namespace CareFlowLite.DTOs;

public class IncidentDto
{
    public int? PatientId {get; set;}
    public Severity Severity{get; set;}
    public string Title {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
}