using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.Todo.Models
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
    }
}
