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
    public class StoreRepository : IStoreRepo
    {
        private readonly Models.StoreApplicationAngularAppContext _context;

        public StoreRepository(Models.StoreApplicationAngularAppContext context)
        {
            _context = context;
        }



        public async Task<List<Store>> StoreListAsync()
        {
            List<Store> stores = await _context.Stores.FromSqlRaw<Store>("SELECT * FROM Store").ToListAsync();

            List<Store> s = new List<Store>();
            foreach (Store s1 in stores)
            {
                s.Add(s1);
            }
            return s;
        }




       
    }
}
