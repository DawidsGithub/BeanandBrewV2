using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanandBrewV2.Data;
using BeanandBrewV2.Models;
using Microsoft.AspNetCore.Identity;

namespace BeanandBrewV2.Controllers
{
    public class CoffeeOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CoffeeOrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CoffeeOrders
        public async Task<IActionResult> Index()
        {
              return _context.CoffeeOrder != null ? 
                          View(await _context.CoffeeOrder.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CoffeeOrder'  is null.");
        }

        // GET: CoffeeOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoffeeOrder == null)
            {
                return NotFound();
            }

            var coffeeOrder = await _context.CoffeeOrder
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (coffeeOrder == null)
            {
                return NotFound();
            }

            return View(coffeeOrder);
        }

        // GET: CoffeeOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoffeeOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CoffeeId,CoffeeName,CoffeeAmount")] CoffeeOrder coffeeOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffeeOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coffeeOrder);
        }

        // GET: CoffeeOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoffeeOrder == null)
            {
                return NotFound();
            }

            var coffeeOrder = await _context.CoffeeOrder.FindAsync(id);
            if (coffeeOrder == null)
            {
                return NotFound();
            }
            return View(coffeeOrder);
        }

        // POST: CoffeeOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CoffeeId,CoffeeName,CoffeeAmount")] CoffeeOrder coffeeOrder)
        {
            if (id != coffeeOrder.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffeeOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeOrderExists(coffeeOrder.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(coffeeOrder);
        }

        // GET: CoffeeOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoffeeOrder == null)
            {
                return NotFound();
            }

            var coffeeOrder = await _context.CoffeeOrder
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (coffeeOrder == null)
            {
                return NotFound();
            }

            return View(coffeeOrder);
        }

        // POST: CoffeeOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoffeeOrder == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CoffeeOrder'  is null.");
            }
            var coffeeOrder = await _context.CoffeeOrder.FindAsync(id);
            if (coffeeOrder != null)
            {
                _context.CoffeeOrder.Remove(coffeeOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeeOrderExists(int id)
        {
          return (_context.CoffeeOrder?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }

        [Route("/order/coffee/{CoffeeId}")]

        public async Task<IActionResult> Order(int CoffeeId)
        {
            CoffeeOrder order = new CoffeeOrder();
            order.CoffeeAmount = 0;
            order.CoffeeId = CoffeeId;
            order.User = await _userManager.GetUserAsync(User);
            order.UserId = _userManager.GetUserAsync(User).Result!.Id;
            _context.Add(order);
            await _context.SaveChangesAsync();
            return Redirect("/");
        }
    }

}
