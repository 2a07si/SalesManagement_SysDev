using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class THattyuDetail
{
    public int HaDetailID { get; set; }

    public int HaID { get; set; }

    public int PrID { get; set; }

    public int HaQuantity { get; set; }

    public virtual THattyu Ha { get; set; } = null!;

    public virtual MProduct Pr { get; set; } = null!;
}
