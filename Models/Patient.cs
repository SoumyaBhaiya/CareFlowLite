namespace CareFlowLite.Models;

public class Patient
{
    public int Id { get; set; }
    public string name {get; set;} = string.Empty;
    public int Age {get; set;}
    public string Gender {get; set;} = string.Empty;
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
} 