using System.ComponentModel.DataAnnotations;

namespace EntityProjects.Models;

public class Todo
{
    public int Id { get; set; }
    public string Task { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public User? Assignee { get; set; }
}