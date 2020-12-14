using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using classes.Providers;
using EFDataAccessLibrary.Models;
using classes.Models;

namespace classes.Controllers
{
    public class TodoController : Controller
    {
        private readonly IDataProvider<Todo> dataProvider;
        private readonly DataContext TodoContext;
        // GET: TodoController1

        public TodoController(IDataProvider<Todo> dataProvider, DataContext context)
        {
            this.dataProvider = dataProvider;
            this.TodoContext = context;
        }
        public ActionResult Index()
        {
            var MyTodos = TodoContext.Todos;
            return View(MyTodos);
        }

        // GET: TodoController1/Details/5
        public ActionResult Details(int id)
        {
            return View(dataProvider.Get(id));
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
                dataProvider.Add(todo);
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
            return View(dataProvider.Get(id));
        }

        // POST: TodoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Todo todo)
        {
            try
            {
                dataProvider.Update(todo);
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
            return View(dataProvider.Get(id));
        }

        // POST: TodoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                dataProvider.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
