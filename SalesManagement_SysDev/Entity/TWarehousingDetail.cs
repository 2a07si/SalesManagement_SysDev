using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TWarehousingDetail
{
    public int WaDetailID { get; set; }

    public int WaID { get; set; }

    public int PrID { get; set; }

    public int WaQuantity { get; set; }

    public virtual MProduct Pr { get; set; } = null!;

    public virtual TWarehousing Wa { get; set; } = null!;
}
