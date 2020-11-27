using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using classes.Models.Todo;

namespace classes.Controllers
{
    public class TodoController : Controller
    {

        private static List<Todo> TodoList = new List<Todo>
        {
            new Todo{Id = 1, Name = "Todo for Monday", Description = "Make breakfast"}
        };
        // GET: TodoController1
        public ActionResult Index()
        {
            return View(TodoList);
        }

        // GET: TodoController1/Details/5
        public ActionResult Details(int id)
        {
            return View(TodoList.FirstOrDefault(todo => todo.Id == id));
        }

        // GET: TodoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Todo todo)
        {

            try
            {
                TodoList.Add(todo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(todo);
            }
        }

        // GET: TodoController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View(TodoList.FirstOrDefault(todo => todo.Id == id));
        }

        // POST: TodoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Todo todo)
        {
            try
            {
                TodoList.RemoveAll(t => t.Id == id);
                TodoList.Add(todo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController1/Delete/5
        public ActionResult Delete(int id, Todo todo)
        {
            return View(TodoList.FirstOrDefault(todo => todo.Id == id));
        }

        // POST: TodoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                TodoList.RemoveAll(t => t.Id == id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
