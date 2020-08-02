using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCartMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _accessor;

        public CartController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Submit()
        {
            var newValue = GetQuantity() + 1;

            _accessor.HttpContext.Response.Cookies.Append("quantity", newValue.ToString());

            return RedirectToAction("Index");
        }

        private int GetQuantity()
        {
            var current = _accessor.HttpContext.Request.Cookies["quantity"];

            if (!int.TryParse(current, out int value))
            {
                value = 0;
            }

            return value;
        }
    }
}
