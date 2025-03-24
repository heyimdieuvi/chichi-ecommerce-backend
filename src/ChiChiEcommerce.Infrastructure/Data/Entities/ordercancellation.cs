using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("ordercancellation")]
public partial class ordercancellation
{
    [Key]
    public int cancellationid { get; set; }

    public int? orderid { get; set; }

    [StringLength(50)]
    public string? cancelledby { get; set; }

    public string? reason { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? cancelledat { get; set; }

    [ForeignKey("orderid")]
    [InverseProperty("ordercancellations")]
    public virtual order? order { get; set; }
}
