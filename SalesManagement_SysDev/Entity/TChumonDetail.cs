using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TChumonDetail
{
    public int ChDetailID { get; set; }

    public int ChID { get; set; }

    public int PrID { get; set; }

    public int ChQuantity { get; set; }

    public virtual TChumon Ch { get; set; } = null!;

    public virtual MProduct Pr { get; set; } = null!;
}
