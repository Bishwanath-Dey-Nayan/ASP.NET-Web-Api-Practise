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

        public HttpResponseMessage Get(int id)
        {
            using (EmployeeDBEntities db = new EmployeeDBEntities())
            {
                var entity = db.Employees.Where(e => e.ID == id).FirstOrDefault();
                if(entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,entity);
                }
                else
                {
                     return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id =" + id.ToString() + " not found");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] Employee emp)
        {
            using (EmployeeDBEntities db = new EmployeeDBEntities())
            {
                try
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, emp);
                    message.Headers.Location = new Uri(Request.RequestUri +"/"+ emp.ID.ToString());
                    return message;
                }
                catch(Exception ex)
                {
                     return  Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }

            }
        }
    }
}
