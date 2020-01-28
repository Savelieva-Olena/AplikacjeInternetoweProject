using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AplikacjeInternetoweProject.Controllers
{
    public class ShoppingCartController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
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
        public ActionResult UpdateCart(FormCollection fc)
        {
            string[] quantity =fc.GetValues("quantity");
            List<Cart> lsCart = (List<Cart>)Session["Cart"];
            for (int i = 0; i < lsCart.Count; i++)
            {
                lsCart[i].Quantity = Convert.ToInt32(quantity[i]);
            }
            return View("Index");
        }
    }
}