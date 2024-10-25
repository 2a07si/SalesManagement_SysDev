//////////////////////////
//・クラス名
//・解説の内容
//-フォーム間の遷移を管理するクラス
//-現在のフォームを保持し、他のフォームに遷移するためのメソッドを提供する。
//-各画面遷移メソッドは、適切なフォームを作成し、NavigateToメソッドを使用して遷移を行う。
//・その他特筆事項
//-フォーム遷移時に現在のフォームを半透明にする機能を追加。
//-このクラスは、主にメインメニューや他の管理画面への遷移を目的とする。
//////////////////////////

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
            // 現在のフォームを透明化 
            currentForm.TransparencyKey = currentForm.BackColor;
            currentForm.Opacity = 0.5; // 半透明に設定 

            targetForm.Show();

            if (hideCurrent)
            {
                currentForm.Hide();
            }
        }

        // メインメニューに戻る処理 
        internal void NavigateToMainMenu()
        {
            mainmenu1 mainMenuForm = new mainmenu1();
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
            lssue lssueForm = new lssue(); // 発注書発行画面の新しいインスタンスを作成
            NavigateTo(lssueForm); // 発注書発行画面に遷移
        }

        //注文画面に遷移
        internal void NavigateToOrderForm()
        {
            order orderForm = new order();
            NavigateTo(orderForm);
        }

        //発注画面遷移
        internal void NavigateToHorderForm()
        {
            horder horderForm = new horder();
            NavigateTo(horderForm);
        }

        //入庫画面遷移
        internal void NavigateToReceivingstockForm()
        {
            receivingstock receivingstockForm = new receivingstock();
            NavigateTo(receivingstockForm);
        }

        //顧客画面遷移
        internal void NavigateCustomerForm()
        {
            customer customerForm = new customer();
            NavigateTo(customerForm);
        }

        //社員画面遷移
        internal void NavigateEmployeeForm()
        {
            employee employeeForm = new employee();
            NavigateTo(employeeForm);
        }

        //商品画面遷移
        internal void NavigateMerchandiseForm()
        {
            merchandise merchandiseForm = new merchandise();
            NavigateTo(merchandiseForm);
        }

        //在庫画面遷移
        internal void NavigateStockForm()
        {
            stock stockForm = new stock();
            NavigateTo(stockForm);
        }

        //パスワード変更、新規アカウント作成画面遷移
        internal void NavigateToLogForm()
        {
            LoginKanriGamen loginKanriGamenForm = new LoginKanriGamen();
            NavigateTo(loginKanriGamenForm);
        }
    }
}
