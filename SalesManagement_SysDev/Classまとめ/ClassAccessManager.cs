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
                        // 権限1: 全てのボタンを有効
                        button.Enabled = true;

                            break;

                    case 2:
                        
                        if(button.Name == "Loginkanri")
                        {
                            button.Visible = false;
                        }
                        
                        // 権限2:　商品、在庫、社員、出荷、発注、入庫、ログイン画面が無効
                        if (button.Name == "b_mer" || button.Name == "b_sto" ||
                            button.Name == "b_emp" || button.Name == "b_lss" ||
                            button.Name == "b_hor" || button.Name == "b_rec" ||
                            button.Name == "b_hacchuu" || button.Name == "b_reg")
                        {
                            button.Enabled = false; // アクセス不可のボタン
                            button.BackColor = Color.Gray;

                        }
                        else
                        {
                            button.Enabled = true; // その他のボタンは有効
                        }
                        break;

                    case 3:
                        // 権限3: 出庫は無効
                        if (button.Name == "Loginkanri")
                        {
                            button.Visible = false;
                        }
                        if (button.Name == "b_acc" || button.Name == "b_ord" ||
                            button.Name == "b_cus" || button.Name == "b_emp" ||
                            button.Name == "b_arr" || button.Name == "b_shi" ||
                            button.Name == "b_sal" || button.Name == "b_reg")
                        {
                            button.Enabled = false;
                            button.BackColor = Color.Gray;
                        }
                        else
                        {
                            button.Enabled = true;
                        }
                        break;

                    default:
                        button.Enabled = false; // 権限が不明な場合は無効化
                        break;
                }
            }
        }
        public void SetCB_JU(ComboBox CB)
        {
           
            switch (employeePermission)
            {
                case 1:
                    CB.Items.AddRange(new object[] { "受注", "注文", "出庫", "入荷", "出荷", "売上" });
                    break;
                case 2:
                    CB.Items.AddRange(new object[] { "注文" });
                    break;
                case 3:
                    CB.Items.AddRange(new object[] { "受注", "出庫", "入荷", "出荷", "売上" });
                    break;
                default:
                    break; // 不明な権限の場合はすべて非表示のまま
            }
        }
        public void SetCB_HN(ComboBox CB)
        {
            switch (employeePermission)
            {
                case 1:
                    CB.Items.AddRange(new object[] { "発注", "入庫" });
                    break;
                case 3:
                    CB.Items.AddRange(new object[] { "発注", "入庫" });
                    break;
                default:
                    break; // 不明な権限の場合はすべて非表示のまま
            }
        }
        public void SetCB_mas(ComboBox CB)
        {
            switch (employeePermission)
            {
                case 1:
                    CB.Items.AddRange(new object[] {"顧客", "商品","在庫","社員" });
                    break;
                case 2:
                    CB.Items.AddRange(new object[] { "商品","在庫" });
                    break;
                case 3:
                    CB.Items.AddRange(new object[] {"顧客"});
                    break;
                default:
                    break; // 不明な権限の場合はすべて非表示のまま
            }
        }
    }
}

