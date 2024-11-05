using SalesManagement_SysDev.Main_LoginForm;
using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Classまとめ
{
    internal class ClassChangeForms
    {
        private Form currentForm;

        public ClassChangeForms(Form currentForm)
        {
            this.currentForm = currentForm;
        }

        // 汎用メソッド: 別のフォームに画面遷移 
        internal void NavigateTo(Form targetForm, bool hideCurrent = true)
        {
            try
            {
                // 現在のフォームを透明化  
                currentForm.TransparencyKey = currentForm.BackColor;
                currentForm.Opacity = 0.5; // 半透明に設定  

                // フォームの初期化処理（必要に応じて）
                targetForm.Load += (s, e) =>
                {
                    try
                    {
                        // 初期化処理をここに追加
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"フォームの初期化中にエラーが発生しました: {ex.Message}", "初期化エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                targetForm.Show();

                if (hideCurrent)
                {
                    currentForm.Hide();
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show($"指定されたフォームが見つかりません: {targetForm.Name}", "フォームエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"このフォームへのアクセス権がありません: {targetForm.Name}", "権限エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"予期しないエラーが発生しました: {ex.Message}", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // メインメニューに戻る処理  
        internal void NavigateToMainMenu()
        {
            mainmenu3 mainMenuForm = new mainmenu3();
            NavigateTo(mainMenuForm);
        }

        // 受注管理画面に遷移  
        public void NavigateToAcceptingOrderForm()
        {
            acceptingorders acceptingordersForm = new acceptingorders(currentForm); // 現在のフォームを渡す 
            NavigateTo(acceptingordersForm); // 受注管理画面に遷移 
        }

        // 出荷管理画面に遷移  
        internal void NavigateToShippingForm()
        {
            shipping shippingForm = new shipping(currentForm);
            NavigateTo(shippingForm);
        }

        // 入荷管理画面に遷移  
        internal void NavigateToArrivalForm()
        {
            arrival arrivalForm = new arrival(currentForm);
            NavigateTo(arrivalForm);
        }

        // 売上管理画面に遷移  
        internal void NavigateToSalesForm()
        {
            sales salesForm = new sales();
            NavigateTo(salesForm);
        }

        // 出庫画面に遷移  
        internal void NavigateToIssueForm()
        {
            issue issueForm = new issue(); // 発注書発行画面の新しいインスタンスを作成 
            NavigateTo(issueForm); // 発注書発行画面に遷移 
        }

        // 注文画面に遷移 
        internal void NavigateToOrderForm()
        {
            order orderForm = new order();
            NavigateTo(orderForm);
        }

        // 発注画面遷移 
        internal void NavigateToHorderForm()
        {
            horder horderForm = new horder();
            NavigateTo(horderForm);
        }

        // 入庫画面遷移 
        internal void NavigateToReceivingstockForm()
        {
            receivingstock receivingstockForm = new receivingstock();
            NavigateTo(receivingstockForm);
        }

        // 顧客画面遷移 
        internal void NavigateToCustomerForm()
        {
            customer customerForm = new customer();
            NavigateTo(customerForm);
        }

        // 社員画面遷移 
        internal void NavigateToEmployeeForm()
        {
            employee employeeForm = new employee();
            NavigateTo(employeeForm);
        }

        // 商品画面遷移 
        internal void NavigateToMerchandiseForm()
        {
            merchandise merchandiseForm = new merchandise();
            NavigateTo(merchandiseForm);
        }

        // 在庫画面遷移 
        internal void NavigateToStockForm()
        {
            stock stockForm = new stock();
            NavigateTo(stockForm);
        }

        // パスワード変更、新規アカウント作成画面遷移 
        internal void NavigateToLogForm()
        {
            LoginKanriGamen loginKanriGamenForm = new LoginKanriGamen();
            NavigateTo(loginKanriGamenForm);
        }

        //mainmenu3遷移
        internal void NavigateTo3()
        {
            mainmenu3 mainmenu3Form = new mainmenu3();
            NavigateTo(mainmenu3Form);
        }
    }
}
