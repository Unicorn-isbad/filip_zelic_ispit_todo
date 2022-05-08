using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.Todo.Models
{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(500)]
        public string Details { get; set; }
        [Required]
        public bool status { get; set; } = false;
        [ForeignKey("ListId")]
        public TodoList TodoList { get; set; }
        public int ListId { get; set; }
    }
}
