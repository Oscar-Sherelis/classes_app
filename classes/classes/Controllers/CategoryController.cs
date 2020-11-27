using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using classes.Models.Category;

namespace classes.Controllers
{
    public class CategoryController : Controller
    {
        private static List<Category> CategoryData = new List<Category>
        {
           new Category { Id = 1, Name = "Category name" }
        };
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(CategoryData);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View(CategoryData.FirstOrDefault(category => category.Id == id));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                CategoryData.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(CategoryData);
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(CategoryData.FirstOrDefault(category => category.Id == id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                CategoryData.RemoveAll(c => c.Id == id);
                CategoryData.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(CategoryData.FirstOrDefault(category => category.Id == id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                CategoryData.RemoveAll(cate => cate.Id == id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
