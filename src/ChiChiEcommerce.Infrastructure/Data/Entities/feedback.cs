using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

[Table("feedback")]
public partial class feedback
{
    [Key]
    public int feedbackid { get; set; }

    public int? userid { get; set; }

    public int? orderid { get; set; }

    public int? rating { get; set; }

    public string? comment { get; set; }

    [ForeignKey("orderid")]
    [InverseProperty("feedbacks")]
    public virtual order? order { get; set; }

    [ForeignKey("userid")]
    [InverseProperty("feedbacks")]
    public virtual user? user { get; set; }
}
