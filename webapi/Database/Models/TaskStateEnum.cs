using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webapi.Database.Models;

[Table("TaskStateEnum")]
[Index("Id", IsUnique = true)]
public partial class TaskStateEnum
{
    [Key]
    public long Id { get; set; }

    public string Value { get; set; } = null!;

    [InverseProperty("StateNavigation")]
    public virtual ICollection<TasksItem> TasksItems { get; } = new List<TasksItem>();
}
