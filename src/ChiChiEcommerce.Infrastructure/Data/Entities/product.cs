using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("product")]
public partial class product
{
    [Key]
    public int productid { get; set; }

    [StringLength(255)]
    public string? name { get; set; }

    public double? price { get; set; }

    public string? description { get; set; }

    public int? stock { get; set; }

    public int? shopid { get; set; }

    public int? categoryid { get; set; }

    [InverseProperty("product")]
    public virtual ICollection<cartitem> cartitems { get; set; } = new List<cartitem>();

    [ForeignKey("categoryid")]
    [InverseProperty("products")]
    public virtual category? category { get; set; }

    [InverseProperty("product")]
    public virtual ICollection<orderitem> orderitems { get; set; } = new List<orderitem>();

    [ForeignKey("shopid")]
    [InverseProperty("products")]
    public virtual shop? shop { get; set; }
}
