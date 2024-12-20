﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Main_LoginForm
{
    public partial class passwordchange : Form
    {

        private bool isPasswordVisible = true;  // パスワード表示状態を管理するフラグ 
        public passwordchange()
        {
            InitializeComponent();


        }

        private void kakutei_Click(object sender, EventArgs e)
        {
            passwordkakutei();
        }

        private void NotFound(TextBox textBox, string itemName, string itemId)
        {
            textBox.BackColor = Color.Yellow;
            textBox.Focus();
            MessageBox.Show($":204\n該当の{itemName}が見つかりません。（{itemName}ID: {itemId}）",
                            "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void passwordkakutei()
        {
            string ShainID = TBID.Text;
            string oldPass = TBold.Text;
            string newPass = TBnew.Text;
            if (TBID.Text == "")
            {
                TBID.Focus();
                MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBold.Text == "")
            {
                TBold.Focus();
                MessageBox.Show("変更前パスワードを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBnew.Text == "")
            {
                TBnew.Focus();
                MessageBox.Show("変更後パスワードを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckNumeric(TBID.Text))
            {
                MessageBox.Show("社員IDは半角数字のみです。");
                return;
            }
            if (!CheckHalfAlphabetNumeric(TBold.Text))
            {
                MessageBox.Show("現パスワードは半角英数字を入力してください。");
                return;
            }
            if (!CheckHalfAlphabetNumeric(TBnew.Text))
            {
                MessageBox.Show("新パスワードは半角英数字を入力してください。");
                return;
            }

            using (var context = new SalesManagementContext())
            {
                // ShainIDで該当社員を検索
                var employee = context.MEmployees.SingleOrDefault(e => e.EmID.ToString() == ShainID);

                if (employee != null)
                {
                    // oldPassの一致確認
                    if (employee.EmPassword == oldPass)
                    {
                        employee.EmPassword = newPass;

                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
                        this.Close(); // 現在のフォームを閉じる 
                        F_login loginForm = new F_login(); // ログインフォームを作成 
                        loginForm.Show(); // ログインフォームを表示 
                    }
                    else
                    {
                        MessageBox.Show("現在のパスワードが一致しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    NotFound(TBID, "社員ID", ShainID);
                }
            }
        }

        private void B_return_Click(object sender, EventArgs e)
        {
            this.Close(); // 現在のフォームを閉じる 
            F_login loginForm = new F_login(); // ログインフォームを作成 
            loginForm.Show(); // ログインフォームを表示 
        }

        private bool CheckHalfAlphabetNumeric(string text)
        {
            bool flg;

            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            if (!regex.IsMatch(text))
                flg = false;
            else
                flg = true;

            return flg;
        }

        private bool CheckNumeric(string text)
        {
            bool flg;

            Regex regex = new Regex("^[0-9]+$");
            if (!regex.IsMatch(text))
                flg = false;
            else
                flg = true;

            return flg;
        }

        private void b_pwHyouji_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (!isPasswordVisible)
            {
                TBold.UseSystemPasswordChar = false; // パスワードを非表示 
                TBold.PasswordChar = '\0';
                b_pwHyouji.Text = "開";  // ボタンのテキストを「表示」に変更 
            }
            else
            {
                TBold.UseSystemPasswordChar = true; // パスワードを表示 

                b_pwHyouji.Text = "閉";  // ボタンのテキストを「非表示」に変更 
            }
        }

        private void b_newHyouji_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (!isPasswordVisible)
            {
                TBnew.UseSystemPasswordChar = false; // パスワードを非表示 
                TBnew.PasswordChar = '\0';
                b_pwHyouji.Text = "開";  // ボタンのテキストを「表示」に変更 
            }
            else
            {
                TBnew.UseSystemPasswordChar = true; // パスワードを表示 

                b_pwHyouji.Text = "閉";  // ボタンのテキストを「非表示」に変更 
            }
        }
    }
}

