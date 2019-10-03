using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BenchMarkResult.Models;
using BenchMarkResult.Services;
using System.Diagnostics;
using System.IO;

namespace BenchMarkResult.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerService serviceObj = new CustomerService();
       
        [HttpGet]
        public  ActionResult<List<Customer>> GetCustomerList_EF()
        {
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            var empList = serviceObj.GetCustomerList_EF();
            sw.Stop();
            long ts = sw.ElapsedMilliseconds;
            StreamWriter sr = new StreamWriter("D:\\Projects\\BenchMarkResult\\Time_EF.txt");
            sr.WriteLine("Time Elapsed for data retrival in EF : " + ts +" milli second");
            sr.Close();
            return empList;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Customer>> GetCustomerList_Dapper()
        {
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            var empList = serviceObj.GetCustomerList_Dapper();
            sw.Stop();
            long ts = sw.ElapsedMilliseconds;
            StreamWriter sr = new StreamWriter("D:\\Projects\\BenchMarkResult\\Time_Dapper.txt");
            sr.WriteLine("Time Elapsed for data retrival in Dapper : " + ts + " milli second");
            sr.Close();
            return empList;
        }

        
 [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Customer>> GetCustomerList_Ado()
        {
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            var empList = serviceObj.GetCustomerList_Ado();
            sw.Stop();
            long ts = sw.ElapsedMilliseconds;
            StreamWriter sr = new StreamWriter("D:\\Projects\\BenchMarkResult\\Time_Ado.txt");
            sr.WriteLine("Time Elapsed for data retrival in Ado.net : " + ts + " milli second");
            sr.Close();
            return empList;
        }
    }
}