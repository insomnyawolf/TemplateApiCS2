using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webapi.Database.Models;

[Table("ProjectStatusEnum")]
[Index("Id", IsUnique = true)]
public partial class ProjectStatusEnum
{
    [Key]
    public long Id { get; set; }

    public string Value { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
