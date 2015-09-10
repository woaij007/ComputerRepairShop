using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerRepairShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string Customer { get; set; }

        // Navigation property
        public  ICollection<OrderDetail> OrderDetails { get; set; }
    }
}