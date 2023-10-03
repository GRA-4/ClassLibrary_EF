using System;
using System.Collections.Generic;

namespace ClassLibrary_EF;

public partial class Post
{
    public int PostId { get; set; }

    public string? Content { get; set; }

    public int? UserId { get; set; }

    public int? TitleId { get; set; }

    public DateTime? DateTime { get; set; }

    public string NamePost { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Title? Title { get; set; }

    public virtual User? User { get; set; }
}
