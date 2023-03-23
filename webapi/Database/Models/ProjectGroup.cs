using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webapi.Database.Models;

[Table("ProjectGroup")]
[Index("Id", IsUnique = true)]
public partial class ProjectGroup
{
    [Key]
    public long Id { get; set; }

    public string? GroupId { get; set; }

    [InverseProperty("Group")]
    public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
