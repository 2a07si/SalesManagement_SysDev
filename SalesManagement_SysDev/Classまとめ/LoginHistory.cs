using SalesManagement_SysDev;

public class LoginHistory
{
    public List<LoginHistoryLog> Logs { get; private set; }

    public LoginHistory()
    {
        Logs = new List<LoginHistoryLog>();
    }

    public void AddLog(LoginHistoryLog log)
    {
        Logs.Add(log);
        SaveToDatabase(log);
    }

    private void SaveToDatabase(LoginHistoryLog log)
    {
        using (var context = new SalesManagementContext())
        {
            context.LoginHistoryLog.Add(log); // ここで実際のDBテーブルにログを追加
            context.SaveChanges(); // 変更を保存
        }
    }
}
