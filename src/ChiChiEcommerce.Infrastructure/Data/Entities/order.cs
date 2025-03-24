using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

public partial class order
{
    [Key]
    public int orderid { get; set; }

    public int? userid { get; set; }

    public int? shopid { get; set; }

    public int? batchid { get; set; }

    [StringLength(50)]
    public string? status { get; set; }

    public double? totalprice { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? createdat { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? expectedreceive { get; set; }

    [ForeignKey("batchid")]
    [InverseProperty("orders")]
    public virtual orderbatch? batch { get; set; }

    [InverseProperty("order")]
    public virtual ICollection<feedback> feedbacks { get; set; } = new List<feedback>();

    [InverseProperty("order")]
    public virtual ICollection<ordercancellation> ordercancellations { get; set; } = new List<ordercancellation>();

    [InverseProperty("order")]
    public virtual ICollection<orderitem> orderitems { get; set; } = new List<orderitem>();

    [InverseProperty("order")]
    public virtual ICollection<orderstatushistory> orderstatushistories { get; set; } = new List<orderstatushistory>();

    [InverseProperty("order")]
    public virtual ICollection<ordervoucher> ordervouchers { get; set; } = new List<ordervoucher>();

    [InverseProperty("order")]
    public virtual ICollection<payment> payments { get; set; } = new List<payment>();

    [ForeignKey("shopid")]
    [InverseProperty("orders")]
    public virtual shop? shop { get; set; }

    [ForeignKey("userid")]
    [InverseProperty("orders")]
    public virtual user? user { get; set; }
}
