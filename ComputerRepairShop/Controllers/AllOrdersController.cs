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
    public class AllOrdersController : ApiController
    {
        private OrdersContext db = new OrdersContext();

        // GET api/AllOrders
        public IQueryable<Order> GetOrders()
        {
          return db.Orders;
        }

        // GET api/Default1/5
        [ResponseType(typeof(Order))]
        public OrderDTO GetOrder(int id)
        {
          Order order = db.Orders.Include("OrderDetails.Part")
              .First(o => o.Id == id);
          if (order == null)
          {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
          }

          return new OrderDTO()
          {
            Details = from d in order.OrderDetails
                      select new OrderDTO.Detail()
                      {
                        PartID = d.Part.Id,
                        Part = d.Part.Name,
                        Price = d.Part.Price,
                        Quantity = d.Quantity
                      }
          };
        }

        // PUT api/Default1/5
        public IHttpActionResult PutOrder(int id, Order order)
        {
          if (!ModelState.IsValid)
          {
            return BadRequest(ModelState);
          }

          if (id != order.Id)
          {
            return BadRequest();
          }

          db.Entry(order).State = EntityState.Modified;

          try
          {
            db.SaveChanges();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!OrderExists(id))
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

        // POST api/Default1
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
          if (!ModelState.IsValid)
          {
            return BadRequest(ModelState);
          }

          db.Orders.Add(order);
          db.SaveChanges();

          return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        // DELETE api/Default1/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
          Order order = db.Orders.Find(id);
          if (order == null)
          {
            return NotFound();
          }

          db.Orders.Remove(order);
          db.SaveChanges();

          return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
          if (disposing)
          {
            db.Dispose();
          }
          base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
          return db.Orders.Count(e => e.Id == id) > 0;
        }
    }
  }