using Microsoft.EntityFrameworkCore;
using StoreApplicationAngularAppStorage.Interfaces;
using StoreApplicationAngularAppStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApplicationAngularAppStorage.Repository
{
    public class CustomerRepository: ICustomerRepo
    {
        private readonly Models.StoreApplicationAngularAppContext _context;

        public CustomerRepository(Models.StoreApplicationAngularAppContext context)
        {
            _context = context;
        }




        public async Task<Customer> LoginCustomerAsync(Customer c)
        {
            var c1 = await _context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customer WHERE Email = {0} AND [Password] = {1}", c.Email, c.Password).FirstOrDefaultAsync();
            

            if (c1 == null) return null;

           
            return c1;
        }



        public async Task<List<Customer>> CustomerListAsync()
        {
            List<Customer> customers = await _context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customer").ToListAsync();
           
            
            List<Customer> vu = new List<Customer>();
            foreach (Customer u in customers)
            {
                vu.Add(u);
            }
            return vu;

           // return customers;
        }



        public async Task<Customer> RegisterCustomerAsync(Customer c)
        {
            int response = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Customer(FirstName, LastName, Email, [Password]) VALUES ({0},{1},{2},{3})", c.FirstName, c.LastName, c.Email, c.Password);
            if (response != 1) return null;
            return await LoginCustomerAsync(c);
        }


    }
}
