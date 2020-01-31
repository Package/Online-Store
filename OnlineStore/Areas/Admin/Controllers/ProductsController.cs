using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using OnlineStore.Services.Interfaces;
using OnlineStore.Areas.Admin.ViewModels;
using System.Data.Entity.Migrations;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private StoreContext db = new StoreContext();
        private readonly ICategoryService categoryService;

        public ProductsController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<ActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        public async Task<ActionResult> Create()
        {
            var viewModel = new ManageProductViewModel { Categories = await categoryService.GetCategoriesAsync(db) };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ManageProductViewModel viewModel)
        {
            // Product defaults
            var product = viewModel.Product;
            product.Added = DateTime.Now;

            // Manage categories
            product.Categories = new List<Category>();
            if (viewModel.MainCategory != null)
                product.Categories.Add(categoryService.GetCategory(viewModel.MainCategory.Value, db));
            if (viewModel.SecondaryCategory != null)
                product.Categories.Add(categoryService.GetCategory(viewModel.SecondaryCategory.Value, db));

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = await db.Products.FindAsync(id);
            if (product == null)
                return HttpNotFound();

            var viewModel = new ManageProductViewModel
            {
                Categories = await categoryService.GetCategoriesAsync(db),
                Product = product,
            };

            // Set the categories
            var mainCategory = product.Categories.FirstOrDefault();
            if (mainCategory != null)
            {
                var secondCategory = product.Categories.FirstOrDefault(c => c.Id != mainCategory.Id);
                viewModel.MainCategory = mainCategory?.Id;
                viewModel.SecondaryCategory = secondCategory?.Id;
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ManageProductViewModel viewModel)
        {
            var product = viewModel.Product;

            // Manage product categories
            product.Categories = new List<Category>();
            if (viewModel.MainCategory != null)
                product.Categories.Add(categoryService.GetCategory(viewModel.MainCategory.Value, db));
            if (viewModel.SecondaryCategory != null)
                product.Categories.Add(categoryService.GetCategory(viewModel.SecondaryCategory.Value, db));

            if (ModelState.IsValid)
            {
                db.Products.AddOrUpdate(p => p.Id, product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
