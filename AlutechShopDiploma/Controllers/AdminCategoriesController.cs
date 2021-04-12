using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlutechShopDiploma.SQL;

namespace AlutechShopDiploma.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminCategoriesController : Controller
    {
        ICategoryRepository repository;
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");

        public AdminCategoriesController(ICategoryRepository rep)
        {
            repository = rep;
        }

        public ViewResult Index()
        {
            return View(repository.Categories);
        }
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int categoryId)
        {
            List<string> ids = sqlWorker.SelectDataFromDBMult("SELECT CategoryID from Subcategories where CategoryID="+categoryId);
            if (ids.Count == 0)
            {
                TempData["message"] = string.Format("Категория \"{0}\" удалена.", repository.Categories.FirstOrDefault(c => c.CategoryID == categoryId).Name);
                repository.DeleteCategory(categoryId);
            }
            else
            {
                TempData["mistake"] = string.Format("Невозможно удалить категорию!");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.CreateCategory(category);
                TempData["message"] = string.Format("Новый категория \"{0}\" успешно добавлена.", category.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        public ViewResult Edit(int categoryId)
        {
            Category category = repository.Categories.FirstOrDefault(c => c.CategoryID == categoryId);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.EditCategory(category);
                TempData["message"] = string.Format("Изменение информации о \"{0}\" сохранены", category.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }
    }
}