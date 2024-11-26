using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Entity
{
    public class NyuukoChecker
    {
        public int ID { get; set; }               // ID
        public string SyukkoID { get; set; }      // SyukkoID
        public string JyutyuID { get; set; }      // JyutyuID
        public string PrID { get; set; }          // PrID
        public bool Flag { get; set; }            // Flag (bool)
        public int Quantity { get; set; }         // Quantity
        public bool DelFlag { get; set; }         // DelFlag (bool)
    }
}
