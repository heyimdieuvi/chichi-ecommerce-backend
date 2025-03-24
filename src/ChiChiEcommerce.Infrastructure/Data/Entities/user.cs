using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Index("email", Name = "users_email_key", IsUnique = true)]
public partial class user
{
    [Key]
    public int userid { get; set; }

    [StringLength(255)]
    public string? name { get; set; }

    [StringLength(255)]
    public string? email { get; set; }

    [StringLength(255)]
    public string? password { get; set; }

    [StringLength(50)]
    public string? role { get; set; }

    [InverseProperty("user")]
    public virtual ICollection<cart> carts { get; set; } = new List<cart>();

    [InverseProperty("user")]
    public virtual ICollection<feedback> feedbacks { get; set; } = new List<feedback>();

    [InverseProperty("shipper")]
    public virtual ICollection<orderbatch> orderbatches { get; set; } = new List<orderbatch>();

    [InverseProperty("user")]
    public virtual ICollection<order> orders { get; set; } = new List<order>();

    [InverseProperty("shipperNavigation")]
    public virtual shipper? shipper { get; set; }

    [InverseProperty("owner")]
    public virtual ICollection<shop> shops { get; set; } = new List<shop>();
}
