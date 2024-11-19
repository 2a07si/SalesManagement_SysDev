using System;
using System.Collections.Generic;

namespace SalesManagement_SysDev;

public partial class TOrder
{
    public int OrID { get; set; }

    public int SoID { get; set; }

    public int EmID { get; set; }

    public int ClID { get; set; }

    public string ClCharge { get; set; } = null!;

    public DateTime OrDate { get; set; }

    public int? OrStateFlag { get; set; }

    public int OrFlag { get; set; }

    public string? OrHidden { get; set; }

    public virtual MClient Cl { get; set; } = null!;

    public virtual MEmployee Em { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TArrival> TArrivals { get; set; } = new List<TArrival>();

    public virtual ICollection<TChumon> TChumons { get; set; } = new List<TChumon>();

    public virtual ICollection<TOrderDetail> TOrderDetails { get; set; } = new List<TOrderDetail>();

    public virtual ICollection<TShipment> TShipments { get; set; } = new List<TShipment>();

    public virtual ICollection<TSyukko> TSyukkos { get; set; } = new List<TSyukko>();

    public virtual ICollection<TSale> TSales { get; set; } = new List<TSale>();
}
