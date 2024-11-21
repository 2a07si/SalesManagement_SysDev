using SalesManagement_SysDev.Classまとめ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SalesManagement_SysDev.Classまとめ.GlobalEmpNo;

namespace SalesManagement_SysDev.Entity
{
    public partial class LogHistory_EMP
    {
        public int empID { get; set; }
        public string empName { get; set; }
        public DateTime LoginDateTime { get; set; }
    }

}
