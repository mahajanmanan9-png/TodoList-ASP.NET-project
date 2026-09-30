using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        private static readonly List<Todo> todos = new();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(todos);
        }

        [HttpPost]
        public IActionResult Add(string task)
        {
            if (!string.IsNullOrWhiteSpace(task))
            {
                todos.Add(new Todo
                {
                    Id = nextId++,
                    Task = task.Trim(),
                    IsCompleted = false
                });
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Complete(int id)
        {
            var todo = todos.Find(x => x.Id == id);
            if (todo != null)
                todo.IsCompleted = true;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var todo = todos.Find(x => x.Id == id);
            if (todo != null)
                todos.Remove(todo);

            return RedirectToAction(nameof(Index));
        }
    }
}
