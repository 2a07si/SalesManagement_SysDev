using System;
using System.Collections.Generic;
using SalesManagement_SysDev;


namespace SalesManagement_SysDev;

public partial class TWarehousing
{
    public int WaID { get; set; }

    public int HaID { get; set; }

    public int? EmID { get; set; }

    public DateTime WaDate { get; set; }

    public int? WaShelfFlag { get; set; }

    public string? WaHidden { get; set; }

    public int WaFlag { get; set; }

    public virtual MEmployee Em { get; set; } = null!;

    public virtual THattyu Ha { get; set; } = null!;

    public virtual ICollection<TWarehousingDetail> TWarehousingDetails { get; set; } = new List<TWarehousingDetail>();
}
