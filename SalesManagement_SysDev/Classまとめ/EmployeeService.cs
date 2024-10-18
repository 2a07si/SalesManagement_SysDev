//////////////////////////
//・クラス名
//EmployeeService
//・解説の内容
//- 社員の認証と情報取得を行うサービスクラス。
//- データベースコンテキストを使用して、社員の情報を取得し、認証を行う。
//- 認証が成功した場合、社員名、ポジション名、PoID（職位ID）を出力するメソッドを提供。
//・その他特筆事項
//- 依存性注入を利用して、データベースコンテキストを柔軟に扱うことができる。
//- このクラスを使用することで、ビジネスロジックが分離され、テストが容易になる。
//////////////////////////

// EmployeeService.cs 
using System.Linq;

namespace SalesManagement_SysDev.Classまとめ
{
    public class EmployeeService
    {
        private SalesManagementContext context;

        public EmployeeService(SalesManagementContext context)
        {
            this.context = context;
        }

        /// <summary> 
        /// 社員の認証を行い、成功した場合は社員名、ポジション名、PoID（職位ID）を出力する。 
        /// </summary> 
        /// <param name="empID">社員ID</param> 
        /// <param name="password">パスワード</param> 
        /// <param name="employeeName">出力される社員名</param> 
        /// <param name="positionName">出力されるポジション名</param> 
        /// <param name="poId">出力される職位ID</param> 
        /// <returns>認証が成功した場合はtrue、失敗した場合はfalse。</returns> 
        public bool ValidateEmployee(int empID, string password, out string employeeName, out string positionName, out int poId)
        {
            var employee = context.MEmployees.SingleOrDefault(e => e.EmId == empID);
            if (employee != null && employee.EmPassword == password)
            {
                employeeName = employee.EmName;
                positionName = context.MPositions
                    .Where(p => p.PoId == employee.PoId)
                    .Select(p => p.PoName)
                    .FirstOrDefault();

                // PoID（職位ID）を取得
                poId = employee.PoId;

                return true;
            }

            employeeName = string.Empty;
            positionName = string.Empty;
            poId = 0; // エラー時のデフォルト値
            return false;
        }
    }
}
