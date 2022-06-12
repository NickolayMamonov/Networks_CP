using System.ComponentModel.DataAnnotations;

namespace CourseProject_1.Models;

public class Diagnosis
{

    [Key]
    public int Id { get; set; }
        
    public string Name { get; set; }
    
        
    public virtual ICollection<Patient>? Patients { get; set; }     
}