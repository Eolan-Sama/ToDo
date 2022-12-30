using NLayer.Core.Entity;

namespace NLayer.Core.Models
{
    public class Todo :IEntity

    {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string Description { get; set; }

    public string Status { get; set; }
    public User User { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    }
}
