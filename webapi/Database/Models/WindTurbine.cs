using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webapi.Database.Models;

[Table("WindTurbine")]
[Index("Id", IsUnique = true)]
public partial class WindTurbine
{
    [Key]
    public long Id { get; set; }

    public long ProjectId { get; set; }

    public string Code { get; set; } = null!;

    [ForeignKey("ProjectId")]
    [InverseProperty("WindTurbines")]
    public virtual Project Project { get; set; } = null!;
}
