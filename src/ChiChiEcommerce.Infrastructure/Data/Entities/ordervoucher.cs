using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("ordervoucher")]
public partial class ordervoucher
{
    [Key]
    public int ordervoucherid { get; set; }

    public int? orderid { get; set; }

    public int? voucherid { get; set; }

    [ForeignKey("orderid")]
    [InverseProperty("ordervouchers")]
    public virtual order? order { get; set; }

    [ForeignKey("voucherid")]
    [InverseProperty("ordervouchers")]
    public virtual voucher? voucher { get; set; }
}
