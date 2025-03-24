using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("orderbatch")]
public partial class orderbatch
{
    [Key]
    public int batchid { get; set; }

    public string? location { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? starttime { get; set; }

    [StringLength(50)]
    public string? status { get; set; }

    public int? shipperid { get; set; }

    [InverseProperty("batch")]
    public virtual ICollection<order> orders { get; set; } = new List<order>();

    [ForeignKey("shipperid")]
    [InverseProperty("orderbatches")]
    public virtual user? shipper { get; set; }

    [InverseProperty("currentbatch")]
    public virtual ICollection<shipper> shippers { get; set; } = new List<shipper>();
}
