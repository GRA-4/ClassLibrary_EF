using ClassLibrary_EF.Operations;
using System;
using System.Collections.Generic;

namespace ClassLibrary_EF;

public partial class User
{

    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public int? RoleId { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual Role? Role { get; set; }
}
