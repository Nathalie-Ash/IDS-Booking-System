using System;
using System.Collections.Generic;

namespace IDS.Core.Models;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<CustomUser> Users { get; set; } = new List<CustomUser>();
}
