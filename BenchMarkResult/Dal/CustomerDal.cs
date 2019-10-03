using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchMarkResult.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Npgsql;
using Dapper;

namespace BenchMarkResult.Dal
{
    public class CustomerDal
    {
        public List<Customer> GetCustomerList_EF()
        {
            using (var db = new DBContextEF())
            {
                return db.Customers.FromSqlRaw("Select * from customer").AsNoTracking().ToList();
            }
        }

        public List<Customer> GetCustomerList_Dapper()
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(@"Host=localhost;Port=5432;Username=postgres;Password=reladmin@123;Database=SampleDB"))
            {
                dbConnection.Open();
                return dbConnection.Query<Customer>("SELECT * FROM customer").ToList();
            }
        }

        public List<Customer> GetCustomerList_Ado()
        {
            using (var dbConnection = new NpgsqlConnection(@"Host=localhost;Port=5432;Username=postgres;Password=reladmin@123;Database=SampleDB"))
            {
                dbConnection.Open();
                var sql = "SELECT * FROM customer";
                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                {
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        return (from DataRow dr in resultTable.Rows
                                select new Customer()
                                {
                                    SlNo = Convert.ToInt32(dr["SlNo"]),
                                    CustomerId = Convert.ToInt32(dr["CustomerId"]),
                                    FirstName = Convert.ToString(dr["FirstName"]),
                                    MiddleName = Convert.ToString(dr["MiddleName"]),
                                    LastName = Convert.ToString(dr["LastName"]),
                                    CompanyName = Convert.ToString(dr["CompanyName"]),
                                    SalesPerson = Convert.ToString(dr["SalesPerson"]),
                                    EmailAddress = Convert.ToString(dr["EmailAddress"]),
                                    Phone = Convert.ToString(dr["Phone"]),
                                    ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"])
                                }).ToList();
                    }
                }
            }
        }
    }
}
