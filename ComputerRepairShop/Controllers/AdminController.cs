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
using ComputerRepairShop.Models;

namespace ComputerRepairShop.Controllers
{
    [Authorize(Roles = "admin,employee")]
    public class AdminController : ApiController
    {
        private OrdersContext db = new OrdersContext();

        // GET api/Admin
        public IQueryable<Part> GetParts()
        {
            return db.Parts;
        }

        // GET api/Admin/5
        [ResponseType(typeof(Part))]
        public IHttpActionResult GetPart(int id)
        {
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return NotFound();
            }

            return Ok(part);
        }

        // PUT api/Admin/5
        public IHttpActionResult PutPart(int id, Part part)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != part.Id)
            {
                return BadRequest();
            }

            db.Entry(part).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(id))
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

        // POST api/Admin
        [ResponseType(typeof(Part))]
        public IHttpActionResult PostPart(Part part)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parts.Add(part);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = part.Id }, part);
        }

        // DELETE api/Admin/5
        [ResponseType(typeof(Part))]
        public IHttpActionResult DeletePart(int id)
        {
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return NotFound();
            }

            db.Parts.Remove(part);
            db.SaveChanges();

            return Ok(part);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartExists(int id)
        {
            return db.Parts.Count(e => e.Id == id) > 0;
        }
    }
}