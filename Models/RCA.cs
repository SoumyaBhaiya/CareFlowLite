namespace CareFlowLite.Models;

public class RCA
{
    public int ID {get; set;}
    public int IncidentId {get; set;}

    public string Why1 {get; set;} = string.Empty;
    public string Why2 {get; set;} = string.Empty;
    public string Why3 {get; set;} = string.Empty;

    public string RootCause {get; set;} = string.Empty;
    public string FixApplied {get; set;} = string.Empty;

    public Incident? Incident {get; set;}
}