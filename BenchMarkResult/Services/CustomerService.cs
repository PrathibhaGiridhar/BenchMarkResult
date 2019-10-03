using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchMarkResult.Models;
using BenchMarkResult.Dal;

namespace BenchMarkResult.Services
{
    public class CustomerService
    {
        CustomerDal dalObj = new CustomerDal();

        public List<Customer> GetCustomerList_EF()
        {
            return dalObj.GetCustomerList_EF();
        }

        public List<Customer> GetCustomerList_Dapper()
        {
            return dalObj.GetCustomerList_Dapper();
        }
        
               public List<Customer> GetCustomerList_Ado()
        {
            return dalObj.GetCustomerList_Ado();
        }

    }
}
