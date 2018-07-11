using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MultiPurpose.Context;
using MultiPurpose.Models;

namespace MultiPurpose.Controllers
{
    public class CustomersController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Customers
        public IHttpActionResult GetCustomer()
        {
            var result = (from c in db.Customer
                         select new
                         {
                             id=c.id,
                             firstName = c.firstName,
                             lastName = c.lastName,
                             role = c.role,
                             imageUrl = c.imageUrl,
                             gender = c.gender,
                             city = new
                             {
                                 name = c.city.name,
                                 code = c.city.code
                             }
                         }).ToList();
            return Ok(result);
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = db.Customer.Where(c=>c.id.Equals(id)).Include(b=>b.city).FirstOrDefault();
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.id)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customer.Add(customer);
            db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Customers ON");

            db.SaveChanges();
            db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Customers OFF");

            return CreatedAtRoute("DefaultApi", new { id = customer.id }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(string id)
        {
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customer.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customer.Count(e => e.id == id) > 0;
        }
    }
}