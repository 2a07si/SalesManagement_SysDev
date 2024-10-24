using SalesManagement_SysDev.Classまとめ;
using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    // OrderStatusHandlerクラス: ステータス設定とボタン状態変更を管理 
    public class OrderStatusHandler
    {
        private Label labelStatus;
        private Button confirmButton;

        // コンストラクタ 
        public OrderStatusHandler(Label labelStatus, Button confirmButton)
        {
            this.labelStatus = labelStatus;
            this.confirmButton = confirmButton;
        }

        // 検索ステータスに設定 
        public void SetSearchStatus()
        {
            CurrentStatus.SearchStatus(labelStatus);
            UpdateButtonState();
        }

        // 更新ステータスに設定 
        public void SetUpdateStatus()
        {
            CurrentStatus.UpDateStatus(labelStatus);
            UpdateButtonState();
        }

        // 登録ステータスに設定 
        public void SetRegistrationStatus()
        {
            CurrentStatus.RegistrationStatus(labelStatus);
            UpdateButtonState();
        }

        // 一覧ステータスに設定 
        public void SetListStatus()
        {
            CurrentStatus.ListStatus(labelStatus);
            UpdateButtonState();
        }

        // ボタン状態の更新 
        private void UpdateButtonState()
        {
            // LabelStatusクラスの静的メソッドを直接呼び出す
            LabelStatus.labelStatus.labelstatus(labelStatus, confirmButton);
        }
    }
}
