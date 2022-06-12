using System.ComponentModel.DataAnnotations;

namespace CourseProject_1.Models;

public class Patient
{
    [Key]
    public int Id { get; set; }
        
    public string Name { get; set; }
    public virtual Doctor? Doctor { get; set; }    
    public virtual Diagnosis? Diagnosis { get; set; }    
    
    
}