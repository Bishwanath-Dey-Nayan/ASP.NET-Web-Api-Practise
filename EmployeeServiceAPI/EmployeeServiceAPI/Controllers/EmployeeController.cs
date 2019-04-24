using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace EmployeeServiceAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBEntities db = new EmployeeDBEntities())
            {
                return db.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (EmployeeDBEntities db = new EmployeeDBEntities())
            {
                return db.Employees.Where(e => e.ID == id).FirstOrDefault();
            }
        }
    }
}
