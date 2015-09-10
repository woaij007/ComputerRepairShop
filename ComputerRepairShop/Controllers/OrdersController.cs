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
    [Authorize]
    public class OrdersController : ApiController
    {
        private OrdersContext db = new OrdersContext();

        // GET api/Orders
        public IEnumerable<Order> GetOrders()
        {
          return db.Orders.Where(o => o.Customer == User.Identity.Name);
        }

        // GET api/Orders/5
        public OrderDTO GetOrder(int id)
        {
          Order order = db.Orders.Include("OrderDetails.Part")
              .First(o => o.Id == id && o.Customer == User.Identity.Name);
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

        public HttpResponseMessage PostOrder(OrderDTO dto)
        {
          if (ModelState.IsValid)
          {
            var order = new Order()
            {
              Customer = User.Identity.Name,
              OrderDetails = (from item in dto.Details
                              select new OrderDetail() { PartId = item.PartID, Quantity = item.Quantity }).ToList()
            };

            db.Orders.Add(order);
            db.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, order);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = order.Id }));
            return response;
          }
          else
          {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
          }
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