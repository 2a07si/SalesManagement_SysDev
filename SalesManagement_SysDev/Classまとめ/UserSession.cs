using System.Collections.Generic;

namespace SalesManagement_SysDev
{
    public static class UserSession
    {
        public static List<LoginHistory> LoginHistories { get; set; } = new List<LoginHistory>();

        public static int EmployeeID { get; set; }
        public static string EmployeeName { get; set; }
        public static string PositionName { get; set; }
        public static int EmployeePermission { get; set; }
    }
}
