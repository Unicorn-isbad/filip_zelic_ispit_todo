using Ispit.Todo.Data;
using Ispit.Todo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Todo.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _user;
        public ListController(ApplicationDbContext context, UserManager<IdentityUser> user)
        {
            _context = context;
            _user = user;
        }

        public IActionResult Create(string name)
        {
            try
            {
                if (String.IsNullOrEmpty(name))
                {
                    throw new Exception(message: "Enter list name.");
                }
                var new_list = new TodoList() 
                {
                    Name = name,
                    UserId = _user.GetUserId(User)
                };
                _context.TodoLists.Add(new_list);
                _context.SaveChanges();
                return RedirectToAction("Index", "Task", new { list_id = new_list.Id});
            }
            catch (Exception error)
            {
                return RedirectToAction("Index", "Task", new { msg=error.Message });
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception(message: "Invalid id.");
                }
                var list = _context.TodoLists.FirstOrDefault(l => l.Id == id);
                if (list == null)
                {
                    throw new Exception(message: "List not found.");
                }
                _context.TodoLists.Remove(list);
                _context.SaveChanges();
                return RedirectToAction("Index", "Task", new { msg = "List deleted" });
            }
            catch (Exception error)
            {
                return RedirectToAction("Index", "Task", new { msg = error.Message });
            }

        }
    }
}
