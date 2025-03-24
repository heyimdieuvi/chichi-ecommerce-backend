using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

public partial class shop
{
    [Key]
    public int shopid { get; set; }

    [StringLength(255)]
    public string? name { get; set; }

    public string? location { get; set; }

    public int? ownerid { get; set; }

    [InverseProperty("shop")]
    public virtual ICollection<cart> carts { get; set; } = new List<cart>();

    [InverseProperty("shop")]
    public virtual ICollection<order> orders { get; set; } = new List<order>();

    [ForeignKey("ownerid")]
    [InverseProperty("shops")]
    public virtual user? owner { get; set; }

    [InverseProperty("shop")]
    public virtual ICollection<product> products { get; set; } = new List<product>();

    [InverseProperty("shop")]
    public virtual ICollection<shopschedule> shopschedules { get; set; } = new List<shopschedule>();
}
