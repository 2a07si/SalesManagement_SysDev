﻿using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Classまとめ
{
    internal class CurrentStatus
    {
        // 状態を表す列挙型
        public enum Status
        {
            未設定, // デフォルトの状態
            登録,
            更新,
            検索,
            一覧
        }

        // モードを表す列挙型
        public enum Mode
        {
            通常,
            詳細
        }

        public enum ItemType
        {
            商品,
            顧客
        }

        public enum RankSale
        {
            ランキング,
            セール
        }

        // グローバル変数としての現在の状態を保持
        public static Status CurrentStatusValue { get; private set; } = Status.未設定;

        // モードを保持
        public static Mode CurrentMode { get; private set; } = Mode.通常;

        public static ItemType CurrentRanking { get; private set; } = ItemType.商品;

        public static RankSale CurrentRankSale { get; private set; } = RankSale.ランキング;

        // 状態の変更とラベルの更新
        public static void RegistrationStatus(Label label2)
        {
            CurrentStatusValue = Status.登録;
            label2.Text = "登録";
        }

        public static void UpDateStatus(Label label2)
        {
            CurrentStatusValue = Status.更新;
            label2.Text = "更新";
        }

        public static void SearchStatus(Label label2)
        {
            CurrentStatusValue = Status.検索;
            label2.Text = "検索";
        }

        public static void ListStatus(Label label2)
        {
            CurrentStatusValue = Status.一覧;
            label2.Text = "一覧";
        }

        public static void ResetStatus(Label label2)
        {
            CurrentStatusValue = Status.未設定;
            label2.Text = "未設定";
        }

        // モードを変更するメソッド
        public static void SetMode(Mode mode)
        {
            CurrentMode = mode;
        }

        public static void RankingMode(ItemType mm)
        {
            CurrentRanking = mm;
        }

        public static void RankingSale(RankSale rs)
        {
            CurrentRankSale = rs;
        }
    }
}
