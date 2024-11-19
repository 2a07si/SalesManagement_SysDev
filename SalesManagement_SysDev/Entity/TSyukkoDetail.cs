using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TSyukkoDetail
{
    public int SyDetailID { get; set; }

    public int SyID { get; set; }

    public int PrID { get; set; }

    public int SyQuantity { get; set; }

    public virtual MProduct Pr { get; set; } = null!;

    public virtual TSyukko Sy { get; set; } = null!;
}
