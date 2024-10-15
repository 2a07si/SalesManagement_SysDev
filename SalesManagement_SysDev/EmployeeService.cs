// EmployeeService.cs
using System.Linq;

namespace SalesManagement_SysDev
{
    public class EmployeeService
    {
        private SalesManagementContext context;

        public EmployeeService(SalesManagementContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 社員の認証を行い、成功した場合は社員名とポジション名を出力する。
        /// </summary>
        /// <param name="empID">社員ID</param>
        /// <param name="password">パスワード</param>
        /// <param name="employeeName">出力される社員名</param>
        /// <param name="positionName">出力されるポジション名</param>
        /// <returns>認証が成功した場合はtrue、失敗した場合はfalse。</returns>
        public bool ValidateEmployee(int empID, string password, out string employeeName, out string positionName)
        {
            var employee = context.MEmployees.SingleOrDefault(e => e.EmId == empID);
            if (employee != null && employee.EmPassword == password)
            {
                employeeName = employee.EmName;
                positionName = context.MPositions
                    .Where(p => p.PoId == employee.PoId)
                    .Select(p => p.PoName)
                    .FirstOrDefault();
                return true;
            }

            employeeName = string.Empty;
            positionName = string.Empty;
            return false;
        }
    }
}
