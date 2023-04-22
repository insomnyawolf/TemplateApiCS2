using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webapi.Database.Models;

[Table("TasksItem")]
[Index("Id", IsUnique = true)]
public partial class TasksItem
{
    [Key]
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public long? State { get; set; }

    [ForeignKey("State")]
    [InverseProperty("TasksItems")]
    public virtual TaskStateEnum? StateNavigation { get; set; }
}
