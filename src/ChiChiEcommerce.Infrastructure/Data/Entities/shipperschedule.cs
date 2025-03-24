using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("shipperschedule")]
public partial class shipperschedule
{
    [Key]
    public int scheduleid { get; set; }

    public int? shipperid { get; set; }

    public DateOnly? date { get; set; }

    public int? blockid { get; set; }

    [ForeignKey("blockid")]
    [InverseProperty("shipperschedules")]
    public virtual blockworking? block { get; set; }

    [ForeignKey("shipperid")]
    [InverseProperty("shipperschedules")]
    public virtual shipper? shipper { get; set; }
}
