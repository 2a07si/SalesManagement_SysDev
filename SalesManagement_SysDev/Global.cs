// Global.cs
namespace SalesManagement_SysDev
{
    public static class Global
    {
        public static int EmployeeID { get; set; }
        public static string EmployeeName { get; set; }
        public static string PositionName { get; set; } // ポジション名を保存

        /// <summary>
        /// グローバルデータをリセットする。
        /// </summary>
        public static void Reset()
        {
            EmployeeID = 0;
            EmployeeName = string.Empty;
            PositionName = string.Empty;
        }
    }
}
