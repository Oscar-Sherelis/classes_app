using classes.Models;
using classes.Providers;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace classes.Controllers
{
    public class LabelController : Controller
    {

        private readonly DataContext LabelContext;
        private readonly IDataProvider<Label> dataProvider;

        public LabelController(IDataProvider<Label> dataProvider, DataContext context)
        {
            this.dataProvider = dataProvider;
            this.LabelContext = context;
        }

        public ActionResult Index()
        {
            var MyLabels = LabelContext.Labels;
            return View(MyLabels);
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
        public ActionResult Create(Label label)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dataProvider.Add(label);
                    return RedirectToAction(nameof(Index));
                }
                return View(label);
            }
            catch
            {
                return View(label);
            }
        }

        // GET: CategoryController/Edit/5
        // before Task<...> was not used, and was error
        public async Task<ActionResult> Edit(int id)
        {
            // return View(dataProvider.Get(id));
            return View(await LabelContext.Labels.FindAsync(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Label label)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LabelContext.Update(label);

                    await LabelContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(label);
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
        public ActionResult Delete(int id, Label label)
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
