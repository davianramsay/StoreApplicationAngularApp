using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreApplicationAngularAppStorage.Interfaces;
using StoreApplicationAngularAppStorage.Models;

namespace StoreApplicationAngularApp.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreRepo _storeRepo;

        public StoreController(IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        //GET stores



        [HttpGet("storelocations")]
        public async Task<List<Store>> Details()
        {
            Task<List<Store>> store = _storeRepo.StoreListAsync();
            List<Store> store1 = await store;
            return store1;
        }



    }
}
