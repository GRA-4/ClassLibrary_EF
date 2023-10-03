using System;
using System.Collections.Generic;

namespace ClassLibrary_EF;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Title> TitlesTitles { get; set; } = new List<Title>();
}
