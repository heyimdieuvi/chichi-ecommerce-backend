using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("voucher")]
[Index("code", Name = "voucher_code_key", IsUnique = true)]
public partial class voucher
{
    [Key]
    public int voucherid { get; set; }

    [StringLength(50)]
    public string? code { get; set; }

    public double? discountpercentage { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? expirydate { get; set; }

    public double? minorderamount { get; set; }

    public double? maxdiscount { get; set; }

    [InverseProperty("voucher")]
    public virtual ICollection<ordervoucher> ordervouchers { get; set; } = new List<ordervoucher>();
}
