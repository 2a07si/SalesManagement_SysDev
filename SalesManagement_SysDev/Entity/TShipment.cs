using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TShipment
{
    public int ShID { get; set; }

    public int ClID { get; set; }

    public int? EmID { get; set; }

    public int SoID { get; set; }

    public int OrID { get; set; }

    public int? ShStateFlag { get; set; }

    public DateTime? ShFinishDate { get; set; }

    public int ShFlag { get; set; }

    public string? ShHidden { get; set; }

    public virtual MClient Cl { get; set; } = null!;

    public virtual MEmployee? Em { get; set; }

    public virtual TOrder Or { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TShipmentDetail> TShipmentDetails { get; set; } = new List<TShipmentDetail>();
}
