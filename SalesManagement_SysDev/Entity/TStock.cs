using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TStock
{
    public int StID { get; set; }

    public int PrID { get; set; }

    public int StQuantity { get; set; }

    public int StFlag { get; set; }

    public virtual MProduct Pr { get; set; } = null!;
}
