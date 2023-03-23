using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webapi.Database.Models;

[Table("Project")]
[Index("Id", IsUnique = true)]
public partial class Project
{
    [Key]
    public long Id { get; set; }

    public long CompanyId { get; set; }

    public long GroupId { get; set; }

    public long StatusId { get; set; }

    public long DealTypeId { get; set; }

    public string Number { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? AcquisitionDate { get; set; }

    public long? MonthsAcquired { get; set; }

    [Column("Number3LCode")]
    public string Number3Lcode { get; set; } = null!;

    public long Kw { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Projects")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("DealTypeId")]
    [InverseProperty("Projects")]
    public virtual ProjectDealTypeEnum DealType { get; set; } = null!;

    [ForeignKey("GroupId")]
    [InverseProperty("Projects")]
    public virtual ProjectGroup Group { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("Projects")]
    public virtual ProjectStatusEnum Status { get; set; } = null!;

    [InverseProperty("Project")]
    public virtual ICollection<WindTurbine> WindTurbines { get; } = new List<WindTurbine>();
}
