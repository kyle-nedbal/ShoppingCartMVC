using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoppingCartMVC.Data;
using ShoppingCartMVC.Models;

namespace ShoppingCartMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly StoreContext _context;
        private ISession _session;

        public ShoppingCartController(StoreContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _session = accessor.HttpContext.Session;
        }

        // GET: ShoppingCart
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: ShoppingCart/Add/5
        public async Task<IActionResult> Add(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);

            List<Product> list;

            if (product == null)
            {
                return NotFound();
            }
            
            // TODO - Add to session
            if (_session.Keys.Any(x => x == "Cart"))
            {
                list = JsonConvert.DeserializeObject<List<Product>>(_session.GetString("Cart"));
            }
            else
            {
                list = new List<Product>();
            }

            list.Add(product);
            _session.SetString("Cart", JsonConvert.SerializeObject(list));

            TempData["Success"] = $"Successfully added {product.Name} to cart!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Checkout()
        {
            List<Product> list;

            if (_session.Keys.Any(x => x == "Cart"))
            {
                list = JsonConvert.DeserializeObject<List<Product>>(_session.GetString("Cart"));
                _session.SetString("Cart", JsonConvert.SerializeObject(list));
            }
            else
            {
                list = new List<Product>();
            }

            for (int i = 0; i < list.Count; i++)            {                ViewBag.Total = list.Sum(i => i.Price);
            }
            return View(list);
        }
    }
}
