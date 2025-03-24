using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("blockworking")]
public partial class blockworking
{
    [Key]
    public int blockid { get; set; }

    public TimeOnly? starttime { get; set; }

    public TimeOnly? endtime { get; set; }

    [InverseProperty("block")]
    public virtual ICollection<shipperschedule> shipperschedules { get; set; } = new List<shipperschedule>();
}
