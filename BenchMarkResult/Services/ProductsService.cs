using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchMarkResult.Models.MultipleDbContext;
using BenchMarkResult.Dal;

namespace BenchMarkResult.Services
{
    public class ProductsService
    {
        ProductsDal dalObj=new ProductsDal();
        public List<Products> GetProductsList_EF()
        {
            return dalObj.GetProductsList_EF();
        }
    }
}
