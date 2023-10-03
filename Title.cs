using System;
using System.Collections.Generic;

namespace ClassLibrary_EF;

public partial class Title
{
    public int TitleId { get; set; }

    public string NameTitle { get; set; } = null!;

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Genre> GenresGenres { get; set; } = new List<Genre>();

    public virtual ICollection<List> ListsLists { get; set; } = new List<List>();
}
