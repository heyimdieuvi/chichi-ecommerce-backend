using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("cart")]
public partial class cart
{
    [Key]
    public int cartid { get; set; }

    public int? userid { get; set; }

    public int? shopid { get; set; }

    [InverseProperty("cart")]
    public virtual ICollection<cartitem> cartitems { get; set; } = new List<cartitem>();

    [ForeignKey("shopid")]
    [InverseProperty("carts")]
    public virtual shop? shop { get; set; }

    [ForeignKey("userid")]
    [InverseProperty("carts")]
    public virtual user? user { get; set; }
}
