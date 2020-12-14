using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using classes.Providers;
using EFDataAccessLibrary.Models;
using LinqToDB;
using DataContext = EFDataAccessLibrary.Models.DataContext;
using classes.Models;

namespace classes.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext CategoryContext;
        private readonly IDataProvider<Category> dataProvider;
        // GET: CategoryController

        public CategoryController(IDataProvider<Category> dataProvider, DataContext context)
        {
            this.dataProvider = dataProvider;
            this.CategoryContext = context;
        }
        public ActionResult Index()
        {
            // old example bellow is bad practice, because ToList must use pc data to convert and makes aditional step
            // var MyCategories = CategoryContext.Categories.ToList();
            // LINQ can help for optimization, when working with filter sort group
            var MyCategories = CategoryContext.Categories;
            return View(MyCategories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View(dataProvider.Get(id));
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
                if (ModelState.IsValid)
                {
                    dataProvider.Add(category);
                    return RedirectToAction(nameof(Index));
                }
                    return View(category);
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoryController/Edit/5
        // before Task<...> was not used, and was error
        public async Task<ActionResult> Edit(int id)
        {
            // return View(dataProvider.Get(id));
            return View(await CategoryContext.Categories.FindAsync(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryContext.Update(category);
                    // without save it will not make changes in db***
                    // dataProvider.Update(category);

                    // context is wathching object changes
                   await CategoryContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(dataProvider.Get(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
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
