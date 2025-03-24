using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("cartitem")]
public partial class cartitem
{
    [Key]
    public int cartitemid { get; set; }

    public int? cartid { get; set; }

    public int? productid { get; set; }

    public int? quantity { get; set; }

    [ForeignKey("cartid")]
    [InverseProperty("cartitems")]
    public virtual cart? cart { get; set; }

    [ForeignKey("productid")]
    [InverseProperty("cartitems")]
    public virtual product? product { get; set; }
}
