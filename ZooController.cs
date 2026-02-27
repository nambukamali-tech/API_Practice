using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zoo_API.Models;
using Zoo_API.Data;
using Microsoft.AspNetCore.Authorization;

namespace Zoo_API.Controllers
{
    [Authorize]
    public class ZooController : Controller
    {
        private readonly ZooDbContext _context;
        public ZooController(ZooDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var animals = await _context.Zoo.ToListAsync();
            return View(animals);
        }

        [HttpGet]
        public async Task<IActionResult> AddAnimals()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimals(Zoo zoo)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Zoo.Add(zoo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(zoo);
        }

        [HttpGet]
        public async Task<IActionResult> EditAnimals(int id)
        {
            var animals = await _context.Zoo.FindAsync(id);
            if (animals == null)
                return NotFound();
            return View(animals);
        }

        [HttpPost]
        public async Task<IActionResult> EditAnimals(Zoo zoo)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Zoo.Update(zoo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(zoo);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAnimals(int id)
        {
            var animals = await _context.Zoo.FindAsync(id);
            if(animals == null)
                return NotFound();
            return View(animals);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteAnimals(Zoo zoo)
        {
            try
            {
                _context.Zoo.Remove(zoo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
             }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(zoo);
        }

        

        
    }
}
