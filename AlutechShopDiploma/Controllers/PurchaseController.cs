using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlutechShopDiploma.Models;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Services;
using AlutechShopDiploma.Models.ViewModels;

namespace AlutechShopDiploma.Controllers
{
    public class PurchaseController : Controller
    {
        private IOrderRepository orderRepository;
        private IOrderItemRepository orderItemRepository;
        ApplicationDbContext context = new ApplicationDbContext();
        
        public PurchaseController(IOrderItemRepository _orderItemRepository, IOrderRepository _orderRepository)
        {
            orderRepository = _orderRepository;
            orderItemRepository = _orderItemRepository;
        }

        // GET: Purchase
        public ViewResult List()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();

            return View(purchaseViewModel);
        }

        public PartialViewResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult Create(OrderItem item)
        {
            if(ModelState.IsValid)
            {
                orderItemRepository.CreateOrderItem(item);
                TempData["succsess"] = string.Format("Товар успешно добавлен.");
            }
            else
            {
                TempData["mistake"] = string.Format("Произошла ошибка. Проверьте корректность данных");
            }
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());
            return Content("Message");
        }
        
        public ActionResult Delete(int orderItemID)
        {
            TempData["message"] = string.Format("Товар удалён из корзины");
            orderItemRepository.DeleteOrderItem(orderItemID);
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }

        [HttpPost]
        public ActionResult Edit(OrderItem item)
        {
            if(ModelState.IsValid)
            {
                TempData["succsess"] = string.Format("Количество единиц товара успешно изменено.");
                orderItemRepository.EditOrderItemByAmount(item);
            }
            else
            {
                TempData["mistake"] = string.Format("Ошибка. Проверьте корректность вввода данных");
            }
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }
    }
}