using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TSaleDetail
{
    public int SaDetailID { get; set; }

    public int SaID { get; set; }

    public int PrID { get; set; }

    public int SaQuantity { get; set; }

    public decimal SaPrTotalPrice { get; set; }

    public virtual MProduct Pr { get; set; } = null!;

    public virtual TSale Sa { get; set; } = null!;
}
