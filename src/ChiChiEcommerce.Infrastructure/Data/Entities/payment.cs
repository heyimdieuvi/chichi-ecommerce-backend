using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("payment")]
public partial class payment
{
    [Key]
    public int paymentid { get; set; }

    public int? orderid { get; set; }

    [StringLength(50)]
    public string? paymentmethod { get; set; }

    [StringLength(50)]
    public string? paymentstatus { get; set; }

    [ForeignKey("orderid")]
    [InverseProperty("payments")]
    public virtual order? order { get; set; }
}
