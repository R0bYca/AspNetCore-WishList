using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{    
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        List<Item> Items { get; set; }
        public IActionResult Index()
        {
            Items = _context.Items.ToList();
            return View(Items);
        }
        [HttpGet]
        public IActionResult Create()
        {            
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return View("Index");
        }
        public IActionResult Delete(int Id)
        {           
            _context.Items.Remove(Items.Where(i => i.Id == Id).FirstOrDefault());
            _context.SaveChanges();
            return View("Index");
        }
    }
}
