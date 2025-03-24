using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("orderstatushistory")]
public partial class orderstatushistory
{
    [Key]
    public int statushistoryid { get; set; }

    public int? orderid { get; set; }

    [StringLength(50)]
    public string? status { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? updatedat { get; set; }

    [ForeignKey("orderid")]
    [InverseProperty("orderstatushistories")]
    public virtual order? order { get; set; }
}
