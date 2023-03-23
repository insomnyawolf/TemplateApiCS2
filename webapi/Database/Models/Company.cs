using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webapi.Database.Models;

[Table("Company")]
[Index("Id", IsUnique = true)]
public partial class Company
{
    [Key]
    public long Id { get; set; }

    public long CompanyId { get; set; }

    [InverseProperty("Company")]
    public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
