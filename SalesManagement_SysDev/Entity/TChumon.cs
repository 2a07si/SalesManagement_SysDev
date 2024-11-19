using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TChumon
{
    public int ChID { get; set; }
    


    public int SoID { get; set; }

    public int? EmID { get; set; }

    public int ClID { get; set; }

    public int OrID { get; set; }

    public DateTime? ChDate { get; set; }

    public int? ChStateFlag { get; set; }

    public int ChFlag { get; set; }

    public string? ChHidden { get; set; }

    public virtual MClient Cl { get; set; } = null!;

    public virtual MEmployee? Em { get; set; }

    public virtual TOrder Or { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TChumonDetail> TChumonDetails { get; set; } = new List<TChumonDetail>();
}
