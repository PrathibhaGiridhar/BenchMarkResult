using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BenchMarkResult.Models.MultipleDbContext;
using BenchMarkResult.Services;

namespace BenchMarkResult.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        ProductsService objService = new ProductsService();

        [HttpGet]
        public ActionResult<List<Products>> GetProductsList_EF()
        {
            var productList = objService.GetProductsList_EF();
            return productList;
        }

        //[HttpGet]
        //public object Get([FromServices] ProductsDbContext productsDb )
        //{
        //    return new
        //    {
        //        productsDb.Products
        //    };
        //}

    }
}