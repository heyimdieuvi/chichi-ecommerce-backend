using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("orderitem")]
public partial class orderitem
{
    [Key]
    public int orderitemid { get; set; }

    public int? orderid { get; set; }

    public int? productid { get; set; }

    public int? quantity { get; set; }

    [ForeignKey("orderid")]
    [InverseProperty("orderitems")]
    public virtual order? order { get; set; }

    [ForeignKey("productid")]
    [InverseProperty("orderitems")]
    public virtual product? product { get; set; }
}
