
using Microsoft.AspNet.Identity;
using Model;
using Model.Entities;
using Model.Identity;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AplikacjeInternetoweProject.Controllers
{
    public class ShoppingCartController : Controller
    {
        AppDbContext db = new AppDbContext();
        private readonly IOrderRepository orderRepository;
        public ShoppingCartController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;

        }
        public ShoppingCartController() { }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        private void getOrder()
        {
            var order = db.Orders;
            var selectOrder = order.Where(x => x.ApplicationUserId == User.Identity.GetUserId());
            ViewBag.orderModel = selectOrder;   
        }
        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session["Cart"] == null)
            {
                List<Cart> lsCart = new List<Cart>
                {
                    new Cart(db.Products.Find(id),1)
                };
                Session["Cart"] = lsCart;
            }
            else
            {
                List<Cart> lsCart = (List<Cart>)Session["Cart"];
                int check = IsExistingCheck(id);
                if (check == -1)
                {
                    lsCart.Add(new Cart(db.Products.Find(id), 1));
                }
                else
                    lsCart[check].Quantity++;
                //lsCart.Add(new Cart(db.Products.Find(id), 1));
                Session["Cart"] = lsCart;
            }
            return View("Index");
        }
        private int IsExistingCheck(int? id)
        {
            List<Cart> lsCart = (List<Cart>)Session["Cart"];
            for (int i = 0; i < lsCart.Count; i++)
            {
                if (lsCart[i].Product.Id == id)
                    return i;

            }
            return -1;
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int check = IsExistingCheck(id);
            List<Cart> lsCart= (List<Cart>)Session["Cart"];
            lsCart.RemoveAt(check);
            return View("Index");
        }
        public ActionResult UpdateCart(System.Web.Mvc.FormCollection fc)
        {
            string[] quantity =fc.GetValues("quantity");
            List<Cart> lsCart = (List<Cart>)Session["Cart"];
            for (int i = 0; i < lsCart.Count; i++)
            {
                lsCart[i].Quantity = Convert.ToInt32(quantity[i]);
            }
            return View("Index");
        }
        public ActionResult CheckOut(FormCollection ch)
        {
            return View();
        }
        public ActionResult ProcessOrder(FormCollection fcol)
        {
            List<Cart> lsCart = (List<Cart>)Session["Cart"];

            var userId=User.Identity.GetUserId();
            Order order = new Order()
            {
                CustomerName = fcol["cusName"],
                CustomerAddress = fcol["cusPhone"],
                CustomerEmail = fcol["cusEmail"],
                CustomerPhone = fcol["cusAddress"],
                OrderDate = DateTime.Now,
                PaymentType = "Cash",
                Status = "prossesing"
            };
            if (userId != null)
            {
                order.ApplicationUserId = userId;
            }


            db.Orders.Add(order);
            db.SaveChanges();
            foreach(var cart in lsCart)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderId = order.OrderId,
                    ProductId = cart.Product.Id,
                    Quantity = cart.Quantity,
                    Price = cart.Product.Price
                };
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }
            //Clean Session 
            Session.Remove("Cart");
            return View("OrderSuccess");
        }
    }
}