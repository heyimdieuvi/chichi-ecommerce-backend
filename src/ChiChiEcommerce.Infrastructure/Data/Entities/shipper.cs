using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("shipper")]
public partial class shipper
{
    [Key]
    public int shipperid { get; set; }

    [StringLength(50)]
    public string? availabilitystatus { get; set; }

    public int? currentbatchid { get; set; }

    [ForeignKey("currentbatchid")]
    [InverseProperty("shippers")]
    public virtual orderbatch? currentbatch { get; set; }

    [ForeignKey("shipperid")]
    [InverseProperty("shipper")]
    public virtual user shipperNavigation { get; set; } = null!;

    [InverseProperty("shipper")]
    public virtual ICollection<shipperschedule> shipperschedules { get; set; } = new List<shipperschedule>();
}
