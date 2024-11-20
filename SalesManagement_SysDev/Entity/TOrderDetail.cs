using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TOrderDetail
{
    public int OrDetailID { get; set; }

    public int OrID { get; set; }

    public int PrID { get; set; }

    public int OrQuantity { get; set; }

    public decimal OrTotalPrice { get; set; }

    public virtual TOrder Or { get; set; } = null!;

    public virtual MProduct Pr { get; set; } = null!;
}
