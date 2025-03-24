using System.ComponentModel.DataAnnotations;

namespace ToDoListProject.Models;

public class Employee
{
    public int id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
    public Employee()
    {        
    }
    public Employee(int v1, string v2, DateOnly dateOnly)
    {
        id = v1;
        Name = v2;
        BirthDate = dateOnly;
    }

}
