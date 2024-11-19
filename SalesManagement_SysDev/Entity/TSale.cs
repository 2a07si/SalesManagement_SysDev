using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TSale
{
    public int SaID { get; set; }

    public int ClID { get; set; }

    public int SoID { get; set; }

    public int EmID { get; set; }

    public int OrID { get; set; }

    public DateTime SaDate { get; set; }

    public string? SaHidden { get; set; }

    public int SaFlag { get; set; }

    public virtual TOrder Or { get; set; } = null!;

    public virtual MClient Cl { get; set; } = null!;

    public virtual MEmployee Em { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TSaleDetail> TSaleDetails { get; set; } = new List<TSaleDetail>();
}
