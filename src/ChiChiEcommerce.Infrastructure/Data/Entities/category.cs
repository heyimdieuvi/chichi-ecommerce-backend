using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

public partial class category
{
    [Key]
    public int categoryid { get; set; }

    [StringLength(255)]
    public string name { get; set; } = null!;

    public string? description { get; set; }

    [InverseProperty("category")]
    public virtual ICollection<product> products { get; set; } = new List<product>();
}
