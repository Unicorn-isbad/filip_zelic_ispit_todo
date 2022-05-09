using Ispit.Todo.Data;
using Ispit.Todo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Todo.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _user;
        public TaskController(ApplicationDbContext context, UserManager<IdentityUser> user)
        { 
            _context = context;
            _user = user;
        }
        public IActionResult Index(string msg = "", int list_id = 0)
        {
            list_id = (list_id == 0 && _context.TodoLists.Count() > 0) ? _context.TodoLists.First().Id : list_id;
            ViewBag.Message = msg;
            ViewBag.Lists = _context.TodoLists.Where(l=>l.UserId == _user.GetUserId(User)).ToList();
            ViewBag.CurrentList = list_id;
            return View(_context.Tasks.Where(t=>t.ListId == list_id).ToList());
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(string create_details, int list_id)
        {
            try
            {
                if (String.IsNullOrEmpty(create_details))
                {
                    throw new Exception(message: "Cannot create empty task.");
                }
                TodoTask new_task = new TodoTask()
                {
                    Details = create_details,
                    status = false,
                    ListId = list_id
                };
                _context.Tasks.Add(new_task);
                _context.SaveChanges();

                return RedirectToAction("Index", new { list_id = list_id});
            }
            catch (Exception error)
            {
                return RedirectToAction("Index", new { msg = error.Message, list_id = list_id });
            }
        }
        public IActionResult Delete(int id, int list_id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception(message: "Invalid id.");
                }
                var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
                if (task == null)
                {
                    throw new Exception(message: "Task not found.");
                }
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                return RedirectToAction("Index", new { list_id = list_id });
            }
            catch (Exception error)
            {
                return RedirectToAction("Index", new { msg = error.Message, list_id = list_id });
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ChangeStatus(int id, int list_id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception(message: "Invalid id.");
                }
                var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
                if (task == null)
                {
                    throw new Exception(message: "Task not found.");
                }
                task.status = !task.status;
                _context.Tasks.Update(task);
                _context.SaveChanges();
                return RedirectToAction("Index", new { list_id = list_id }) ;
            }
            catch (Exception error)
            {
                return RedirectToAction("Index", new { msg = error.Message, list_id = list_id });
            }
        }

    }
}
