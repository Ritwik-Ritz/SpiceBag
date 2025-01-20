using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Prod.Service.Entities;

public class Product
{
    [Key]
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category {  get; set; }
    public double? UnitPrice { get; set; }
    public double? Quantity { get; set; }

}
