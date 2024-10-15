//////////////////////////
//・クラス名
//ClassChangeForms
//・解説の内容
//- フォームの遷移を管理するクラスで、現在表示されているフォームを保持し、新しいフォームに遷移するためのメソッドを提供。
//- 各遷移メソッドは特定のフォームをインスタンス化し、現在のフォームを非表示または半透明にして新しいフォームを表示する。
//- 汎用的な画面遷移メソッドを使って、コードの重複を避け、メンテナンス性を向上させることを目的としている。
//- メインメニューや各種管理画面への遷移を明示的にサポートしており、新しい管理画面が追加された場合にも容易に拡張可能。
//・その他特筆事項
//- フォーム遷移時に現在のフォームを半透明にすることで、ユーザーに現在の操作を視覚的に理解させる工夫がされている。
//- 各遷移メソッドは、ユーザーの操作をスムーズに行えるように設計されている。
//////////////////////////

using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Classまとめ
{
    internal class ClassChangeForms
    {
        private Form currentForm;  // 現在のフォームを保持する変数

        public ClassChangeForms(Form currentForm)
        {
            this.currentForm = currentForm;  // コンストラクタで渡された現在のフォームを設定
        }

        // 汎用メソッド: 別のフォームに画面遷移 
        public void NavigateTo(Form targetForm, bool hideCurrent = true)
        {
            // 現在のフォームを透明化 
            currentForm.TransparencyKey = currentForm.BackColor; // 現在のフォームの背景色を透明色として設定
            currentForm.Opacity = 0.5; // フォームを半透明に設定

            targetForm.Show(); // 指定されたターゲットフォームを表示

            if (hideCurrent)
            {
                currentForm.Hide(); // hideCurrentがtrueの場合、現在のフォームを非表示にする
            }
        }

        // メインメニューに戻る処理 
        public void NavigateToMainMenu()
        {
            mainmenu1 mainMenuForm = new mainmenu1(); // メインメニューの新しいインスタンスを作成
            NavigateTo(mainMenuForm); // メインメニューに遷移
        }

        // 受注管理画面に遷移 
        public void NavigateToAcceptingOrderForm()
        {
            acceptingorders acceptingordersForm = new acceptingorders(); // 受注管理画面の新しいインスタンスを作成
            NavigateTo(acceptingordersForm); // 受注管理画面に遷移
        }

        // 出荷管理画面に遷移 
        public void NavigateToShippingForm()
        {
            shipping shippingForm = new shipping(currentForm); // 出荷管理画面の新しいインスタンスを作成（現在のフォームを渡す）
            NavigateTo(shippingForm); // 出荷管理画面に遷移
        }

        // 入荷管理画面に遷移 
        public void NavigateToArrivalForm()
        {
            arrival arrivalForm = new arrival(currentForm); // 入荷管理画面の新しいインスタンスを作成（現在のフォームを渡す）
            NavigateTo(arrivalForm); // 入荷管理画面に遷移
        }

        // 売上管理画面に遷移 
        public void NavigateToSalesForm()
        {
            sales salesForm = new sales(); // 売上管理画面の新しいインスタンスを作成
            NavigateTo(salesForm); // 売上管理画面に遷移
        }

        // 発注書発行画面に遷移 
        public void NavigateToIssueForm()
        {
            lssue lssueForm = new lssue(); // 発注書発行画面の新しいインスタンスを作成
            NavigateTo(lssueForm); // 発注書発行画面に遷移
        }

        //注文画面に遷移
        public void NavigateToOrderForm()
        {
            order orderForm = new order();
            NavigateTo(orderForm);
        }
    }
}
