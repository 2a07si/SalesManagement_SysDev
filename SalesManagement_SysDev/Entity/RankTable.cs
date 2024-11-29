using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Entity
{
    public class RankTable
    {
        public int RankID { get; set; } // 自動採番
        public int CustomerID { get; set; }
        public int ShopID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }

}
