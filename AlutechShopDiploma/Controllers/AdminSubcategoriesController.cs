
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlutechShopDiploma.Controllers
{
    public class AdminSubcategoriesController : Controller
    {
        ISubcategoryRepository repository;

        public AdminSubcategoriesController(ISubcategoryRepository rep)
        {
            repository = rep;
        }

        public ViewResult Index()
        {
            return View(repository.Subcategories);
        }
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int subcategoryId)
        {

            TempData["message"] = string.Format("Подкатегория \"{0}\" удалена.", repository.Subcategories.FirstOrDefault(c => c.SubcategoryID == subcategoryId).Name);
            repository.DeleteSubcategory(subcategoryId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                repository.CreateSubcategory(subcategory);
                TempData["message"] = string.Format("Новый категория \"{0}\" успешно добавлена.", subcategory.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(subcategory);
            }
        }

        public ViewResult Edit(int subcategoryId)
        {
            Subcategory subcategory = repository.Subcategories.FirstOrDefault(c => c.SubcategoryID == subcategoryId);
            return View(subcategory);
        }

        [HttpPost]
        public ActionResult Edit(Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                repository.EditSubcategory(subcategory);
                TempData["message"] = string.Format("Изменение информации о \"{0}\" сохранены", subcategory.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(subcategory);
            }
        }
    }
}