using Microsoft.AspNetCore.Mvc;
using Flowers_API.Data;
using Flowers_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Flowers_API.Controllers
{
    public class FlowersController : Controller
    {
        private readonly FlowerDbContext _context;
        public FlowersController(FlowerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var flowers = await _context.Flowers.ToListAsync();
            return View(flowers);
        }

        [HttpGet]
        public async Task<IActionResult> AddFlowers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFlowers(Flowers flowers)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Flowers.Add(flowers);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            return View(flowers);
        }

        [HttpGet]
        public async Task<IActionResult> EditFlowers(int id)
        {
            var flowers = await _context.Flowers.FindAsync(id);
            if(flowers == null)
            {
                return NotFound();
            }
            return View(flowers);

        }

        [HttpPost]
        public async Task<IActionResult> EditFlowers( Flowers flowers)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Flowers.Update(flowers);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(flowers);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFlowers(int id)
        {
            var flowers = await _context.Flowers.FindAsync(id);
            if (flowers == null)
                return NotFound();
            return View(flowers);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFlowers(Flowers flowers)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Flowers.Remove(flowers);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(flowers);
        }
        
    }
}
