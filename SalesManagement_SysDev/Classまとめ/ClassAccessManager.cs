using System.Windows.Forms;

namespace SalesManagement_SysDev.Classまとめ
{
    public class ClassAccessManager
    {
        private int employeePermission;

        public ClassAccessManager(int permission)
        {
            employeePermission = permission;
        }

        public void SetButtonAccess(Control[] buttons)
        {
            foreach (var button in buttons)
            {
                switch (employeePermission)
                {
                    case 1:
                        // 権限1
                        if (button.Name == "b_masuta") // b_masutaは全体からアクセス可能
                        {
                            button.Enabled = true; // 有効
                        }
                        else
                        {
                            button.Enabled = false; // 無効
                        }
                        break;

                    case 2:
                        // 権限2
                        if (button.Name == "b_masuta") // b_masutaは全体からアクセス可能
                        {
                            button.Enabled = true; // 有効
                        }
                        else if (button.Name == "b_acc" || button.Name == "b_ord" ||
                                 button.Name == "b_arr" || button.Name == "b_shi" ||
                                 button.Name == "b_sal")
                        {
                            button.Enabled = false; // 受注、注文、入荷、出荷、売上は無効
                        }
                        else
                        {
                            button.Enabled = true; // その他のボタンは有効
                        }
                        break;

                    case 3:
                        // 権限3
                        if (button.Name == "b_masuta") // b_masutaは全体からアクセス可能
                        {
                            button.Enabled = true; // 有効
                        }
                        else if (button.Name == "b_lss")
                        {
                            button.Enabled = false; // 出庫は無効
                        }
                        else
                        {
                            button.Enabled = true; // その他のボタンは有効
                        }
                        break;

                    default:
                        button.Enabled = false; // 権限が不明な場合は無効化
                        break;
                }
            }
        }
    }
}
