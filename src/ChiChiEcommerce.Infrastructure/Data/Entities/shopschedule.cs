using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("shopschedule")]
public partial class shopschedule
{
    [Key]
    public int scheduleid { get; set; }

    public int? shopid { get; set; }

    [StringLength(20)]
    public string? dayofweek { get; set; }

    public TimeOnly? opentime { get; set; }

    public TimeOnly? closetime { get; set; }

    [ForeignKey("shopid")]
    [InverseProperty("shopschedules")]
    public virtual shop? shop { get; set; }
}
