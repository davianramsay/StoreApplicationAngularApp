using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreApplicationAngularAppStorage.Models;
using StoreApplicationAngularAppStorage.Interfaces;

namespace StoreApplicationAngularApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }


        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer
        [HttpGet("customerlist")]
        public async Task<List<Customer>> Details()
        {
            Task<List<Customer>> customer = _customerRepo.CustomerListAsync();
            List<Customer> customer1 = await customer;
            return customer1;
        }


        [HttpGet("login/{email}/{password}")]
        public async Task<ActionResult<Customer>> Login(string email, string password)
        {
            if (!ModelState.IsValid) return BadRequest();
            Customer c = new Customer() { Email = email, Password = password };
            Customer c1 = await _customerRepo.LoginCustomerAsync(c);



            if (c1 == null)
            {
                return NotFound();
            }

            if (c.Password != c1.Password)
            {
                return new Customer { /*Username = "Wrong Password", Password = "1234"*/ };
            }
            return Ok(c1);
        }

        [HttpPost("register/{fname}/{lname}/{email}/{password}")]
        public async Task<ActionResult<Customer>> Register(string fname, string lname, string email, string password)
        {
            if (!ModelState.IsValid) return BadRequest();
            Customer c = new Customer
            {
                FirstName = fname,
                LastName = lname,
                Email = email,
                Password = password
            };
            Customer c1 = await _customerRepo.RegisterCustomerAsync(c);
            if (c1 == null)
            {
                return NotFound();
            }
            return c1;
        }


        //// GET: Customer/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _customerRepo.Customers
        //        .FirstOrDefaultAsync(m => m.CustomerId == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}

        //// GET: Customer/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Customer/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,Email,Password")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _customerRepo.Add(customer);
        //        await _customerRepo.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}

        //// GET: Customer/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _customerRepo.Customers.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(customer);
        //}

        //// POST: Customer/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,Email,Password")] Customer customer)
        //{
        //    if (id != customer.CustomerId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(customer);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CustomerExists(customer.CustomerId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}

        //// GET: Customer/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customers
        //        .FirstOrDefaultAsync(m => m.CustomerId == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}

        //// POST: Customer/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);
        //    _context.Customers.Remove(customer);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CustomerExists(int id)
        //{
        //    return _context.Customers.Any(e => e.CustomerId == id);
        //}
    }
}
