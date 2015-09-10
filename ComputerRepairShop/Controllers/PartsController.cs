using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;
using ComputerRepairShop.Models;

namespace ComputerRepairShop.Controllers
{
    using ComputerRepairShop.Models;
    public class PartsController : ApiController
    {
      private OrdersContext db = new OrdersContext();

      // Project parts to part DTOs.
      private IQueryable<PartDTO> MapParts()
      {
        return from p in db.Parts
               select new PartDTO() { Id = p.Id, Name = p.Name, Price = p.Price, Amount = p.Amount, Description = p.Description };
      }

      public IEnumerable<PartDTO> GetParts()
      {
        return MapParts().AsEnumerable();
      }

      public PartDTO GetPart(int id)
      {
        var part = (from p in MapParts()
                    where p.Id == 1
                       select p).FirstOrDefault();
        if (part == null)
        {
          throw new HttpResponseException(
              Request.CreateResponse(HttpStatusCode.NotFound));
        }
        return part;
      }
      protected override void Dispose(bool disposing)
      {
        db.Dispose();
        base.Dispose(disposing);
      }
    }
}
