using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TArrivalDetail
{
    public int ArDetailID { get; set; }

    public int? ArID { get; set; }

    public int? PrID { get; set; }

    public int? ArQuantity { get; set; }

    public virtual TArrival? Ar { get; set; }

    public virtual MProduct? Pr { get; set; }
}
