using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TSyukko
{
    public int SyID { get; set; }

    public int? EmID { get; set; }

    public int ClID { get; set; }

    public int SoID { get; set; }

    public int OrID { get; set; }

    public DateTime? SyDate { get; set; }

    public int? SyStateFlag { get; set; }

    public int SyFlag { get; set; }

    public string? SyHidden { get; set; }

    public virtual MClient Cl { get; set; } = null!;

    public virtual MEmployee? Em { get; set; }

    public virtual TOrder Or { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TSyukkoDetail> TSyukkoDetails { get; set; } = new List<TSyukkoDetail>();
}
