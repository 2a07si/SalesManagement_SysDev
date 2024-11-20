using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TShipmentDetail
{
    public int ShDetailID { get; set; }

    public int ShID { get; set; }

    public int PrID { get; set; }

    public int ShQuantity { get; set; }

    public virtual MProduct Pr { get; set; } = null!;

    public virtual TShipment Sh { get; set; } = null!;
}
