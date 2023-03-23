using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webapi.Database.Models;

[Table("ProjectDealTypeEnum")]
[Index("Id", IsUnique = true)]
public partial class ProjectDealTypeEnum
{
    [Key]
    public long Id { get; set; }

    public string Value { get; set; } = null!;

    [InverseProperty("DealType")]
    public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
