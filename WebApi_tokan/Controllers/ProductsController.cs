using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi_tokan.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        [Authorize]
        [Route("api/Products",Name ="GetProducts")]
        public IEnumerable<Employee> GetEmployees()
        {
            using(var db= new TestEntities())
            {
                var employees=db.Employees.ToList();
                return employees;
            }
        }
    }
}
