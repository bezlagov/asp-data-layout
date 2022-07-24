using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using task3_5.Models;

namespace task3_5.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = CreateRandomProducts(5);

            ViewBag.products = products;

            return View(products);
        }

        private List<Product> CreateRandomProducts(int count)
        {
            List<Product> products = new List<Product>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                products.Add(new Product()
                {
                    Id = random.Next(0,1000),
                    Price = (float)random.NextDouble()* random.Next(0, 1000),
                    Name = RandomString(random.Next(4, 20))
                });
            }

            return products;
        }


        private string RandomString(int length)
        {
         Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
