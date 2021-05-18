using System;
using System.Web.Mvc;
using AlutechShopDiploma.Models;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Services;
using AlutechShopDiploma.Models.ViewModels;
using AlutechShopDiploma.Models.Concrete;
using AlutechShopDiploma.SQL;
using System.Collections.Generic;
using System.Linq;

namespace AlutechShopDiploma.Controllers
{
    public class PurchaseController : Controller
    {
        private IOrderRepository orderRepository;
        private IOrderItemRepository orderItemRepository;
        private IShippingDetailRepository shippingDetailRepository;
        ApplicationDbContext context = new ApplicationDbContext();
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");

        public PurchaseController(IOrderItemRepository _orderItemRepository, IOrderRepository _orderRepository, IShippingDetailRepository _shippingDetailRepository)
        {
            orderRepository = _orderRepository;
            orderItemRepository = _orderItemRepository;
            shippingDetailRepository = _shippingDetailRepository;
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
                OrderItemsWorker orderItemsWorker = new OrderItemsWorker(GoodItemController.goodID, item);
                if (orderItemsWorker.IsCompletedItem())
                {
                    orderItemRepository.CreateOrderItem(item);

                    OrderWorker orderWorker = new OrderWorker();
                    double price = orderWorker.CountOrderPrice();

                    orderRepository.EditOrderByTotalPrice(orderWorker.DefineOrderID(), price);
                    TempData["succsess"] = string.Format("Товар успешно добавлен.");
                }
                else
                {
                    TempData["mistake"] = string.Format("К сожалению, выбранного вами количества товара не хватает на складе. Измените, пожалуйста, количество. На данный момент на складе " + orderItemsWorker.GetGoodCountOnWarehouse() + " шт. вашего товара на складе.");
                }
            }
            else
            {
                TempData["mistake"] = string.Format("Произошла ошибка. Проверьте корректность данных.");
            }
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());
            return Content("Message");
        }
        
        public ActionResult Delete(int orderItemID)
        {
            TempData["message"] = string.Format("Товар удалён из корзины");
            orderItemRepository.DeleteOrderItem(orderItemID);

            OrderWorker orderWorker = new OrderWorker();
            double price = orderWorker.CountOrderPrice();

            orderRepository.EditOrderByTotalPrice(orderWorker.DefineOrderID(), price);

            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }

        [HttpPost]
        public ActionResult Edit(int orderItemID, PurchaseViewModel model)
        {
            if(ModelState.IsValid)
            {
                OrderItem orderItem = context.OrderItems.Find(orderItemID);
                orderItem.Ammount = model.goodAmmount;
                OrderItemsWorker orderItemsWorker = new OrderItemsWorker(orderItem.GoodID, orderItem);
                if (orderItemsWorker.IsCompletedItem())
                {
                    TempData["succsess"] = string.Format("Количество единиц товара успешно изменено.");
                    orderItemRepository.EditOrderItemByAmount(orderItemID, model.goodAmmount);

                    OrderWorker orderWorker = new OrderWorker();
                    double price = orderWorker.CountOrderPrice();

                    orderRepository.EditOrderByTotalPrice(orderWorker.DefineOrderID(), price);
                }
                else
                {
                    TempData["mistake"] = string.Format("К сожалению, выбранного вами количества товара не хватает на складе. Измените, пожалуйста, количество. На данный момент на складе " + orderItemsWorker.GetGoodCountOnWarehouse() + " шт. вашего товара на складе.");
                }
            }
            else
            {
                TempData["mistake"] = string.Format("Ошибка. Проверьте корректность вввода данных");
            }
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }

        [HttpPost]
        public ActionResult SpendBonuses(PurchaseViewModel model)
        {
            UsersWorker worker = new UsersWorker(HttpContext.User.Identity.Name);
            double bonusAmmount = worker.GetUserBalance();

            OrderWorker orderWorker = new OrderWorker();

            if (bonusAmmount < model.userBalance)
            {
                TempData["mistake"] = string.Format("Вашего баланса недостаточно. Введите меньшую сумму.");
            }
            else
            {
                if(model.userBalance < orderWorker.GetOrderPrice())
                {
                    double totalPrice = orderWorker.GetOrderPrice() - model.userBalance;
                    orderRepository.EditOrderByTotalPrice(orderWorker.DefineOrderID(), totalPrice);
                    TempData["succsess"] = string.Format("Сумма в " + model.userBalance + " руб. успешно списана с вашего баланса.");
                    ApplicationUser applicationUser = context.Users.Find(worker.GetUserID());

                    applicationUser.bonusAmmount = applicationUser.bonusAmmount - model.userBalance;
                    context.SaveChanges();
                }
                else
                {
                    double orderPrice = orderWorker.GetOrderPrice();
                    double totalPrice = 0;
                    orderRepository.EditOrderByTotalPrice(orderWorker.DefineOrderID(), totalPrice);
                    TempData["succsess"] = string.Format("Сумма в " + orderPrice + " руб. успешно списана с вашего баланса. Так как сумма на списание, котрую вы ввели, " +
                        "больше суммы заказа, то с вашего баланса будет списано " + orderPrice + " р.");

                    ApplicationUser applicationUser = context.Users.Find(worker.GetUserID());

                    applicationUser.bonusAmmount = applicationUser.bonusAmmount - orderPrice;
                    context.SaveChanges();
                }
            }
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());
            return Content("Message");
        }

        public PartialViewResult FinishOrder()
        {
            return PartialView();
        }

        [HttpPost]
        public RedirectToRouteResult FinishOrder(ShippingDetail shippingDetail)
        {
            if(ModelState.IsValid)
            {
                OrderWorker orderWorker = new OrderWorker();
                int orderId = orderWorker.DefineOrderID();
                Order order = context.Orders.Find(orderId);

               
                IEnumerable<OrderItem> items = context.OrderItems.Where(x => x.OrderID == order.OrderID);
                bool flag = true;

                foreach(var item in items)
                {
                    OrderItemsWorker orderItemsWorker = new OrderItemsWorker(item.GoodID, item);
                    if (!orderItemsWorker.IsCompletedItem())
                    {
                        flag = false;
                        Dictionary<Good, int> restGoods = orderItemsWorker.GetGoodsCountOnWarehouse();
                        foreach (var good in restGoods)
                        {
                            TempData["message"] += string.Format("К сожалению, выбранного вами количества товара не хватает на складе." +
                                "Измените, пожалуйста, количество. На данный момент на складе " + good.Value + " шт. " + good.Key.Name + " на складе." + "\n");
                        }
                    }
                }

                if (flag)
                {
                    EmailSettings emailSettings = new EmailSettings();
                    EmailProcessor emailService = new EmailProcessor(emailSettings);

                    shippingDetailRepository.CreateShippingDetail(shippingDetail);
                    emailService.ProcessUserOrder(shippingDetail, orderWorker.CountUserBonus(order));

                    orderRepository.EditOrderByIsFinished(orderWorker.DefineOrderID(), true);

                    TempData["succsess"] = string.Format("Ваш заказ отправлен. Пожалуйста, ожидайте связи менеджера с вами.");
                }
            }
            else
            {
                TempData["mistake"] = string.Format("Произошла ошибка при вводе контактных данных. Проверьте правильность ввода.");
            }

            return RedirectToAction("Index","Home");
        }

        public ViewResult ConfirmPurchase(string userId, int orderId)
        {
            OrderWorker orderWorker = new OrderWorker();
            ApplicationUser applicationUser = context.Users.Find(userId);
            Order order = context.Orders.Find(orderId);

            int shippingDetailId = Convert.ToInt32(sqlWorker.SelectDataFromDB("SELECT ShippingDetailID FROM ShippingDetails WHERE OrderId = " + orderId));

            ShippingDetail shippingDetail = context.ShippingDetails.Find(shippingDetailId);

            EmailSettings emailSettings = new EmailSettings();
            EmailProcessor emailService = new EmailProcessor(emailSettings);

            if (order.IsOrdered == false)
            {
                applicationUser.bonusAmmount += orderWorker.CountUserBonus(order);
                orderRepository.EditOrderByIsOrdered(orderId, true);
                ViewData["success"] = "Заказ успешно обработан. Клиенту " + applicationUser.UserName + " направлено вознаграждение за покупку в размере " + orderWorker.CountUserBonus(order) + " р.";
                emailService.ProcessPurchaseConfrimation(orderWorker.CountUserBonus(order), shippingDetail);
            }
            else
            {
                ViewData["mistake"] = "Данный клиент уже получал вознаграждение.";
            }
            context.SaveChanges();

            return View();
        }
    }
}