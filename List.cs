using System;
using System.Collections.Generic;

namespace ClassLibrary_EF;

public partial class List
{
    public int ListId { get; set; }

    public string NameList { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Title> TitlesTitles { get; set; } = new List<Title>();
}
