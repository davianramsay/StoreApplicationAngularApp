using StoreApplicationAngularAppStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApplicationAngularAppStorage.Interfaces
{
    public interface ICustomerRepo
    {
        Task<List<Customer>> CustomerListAsync();

        Task<Customer> LoginCustomerAsync(Customer cl);

        Task<Customer> RegisterCustomerAsync(Customer cr);

    }
}
