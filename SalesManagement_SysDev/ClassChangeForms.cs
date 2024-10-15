﻿using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    internal class ClassChangeForms
    {
        private Form currentForm;

        public ClassChangeForms(Form currentForm)
        {
            this.currentForm = currentForm;
        }

        // 別のフォームに画面遷移する汎用メソッド
        public void NavigateTo(Form targetForm, bool hideCurrent = true)
        {
            targetForm.Show();
            if (hideCurrent)
            {
                currentForm.Hide();
            }
        }

        // メインメニューに戻る処理
        public void NavigateToMainMenu()
        {
            mainmenu1 mainMenuForm = new mainmenu1();
            NavigateTo(mainMenuForm);
        }

        // 受注管理画面に遷移
        public void NavigateToOrderForm()
        {
            order orderForm = new order();
            NavigateTo(orderForm);
        }

        // 出荷管理画面に遷移
        public void NavigateToShippingForm()
        {
            shipping shippingForm = new shipping(currentForm);
            NavigateTo(shippingForm);
        }

        // 入荷管理画面に遷移
        public void NavigateToArrivalForm()
        {
            arrival arrivalForm = new arrival(currentForm);
            NavigateTo(arrivalForm);
        }

        // 売上管理画面に遷移
        public void NavigateToSalesForm()
        {
            sales salesForm = new sales();
            NavigateTo(salesForm);
        }

        // 発注書発行画面に遷移
        public void NavigateToIssueForm()
        {
            lssue issueForm = new lssue();
            NavigateTo(issueForm);
        }
    }
}