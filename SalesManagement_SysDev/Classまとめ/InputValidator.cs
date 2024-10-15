//////////////////////////
//・クラス名
//InputValidator
//・解説の内容
//- ユーザー入力の検証を行う静的クラス。
//- 入力が空でないか、整数に変換できるかなどの基本的な検証機能を提供する。
//- 各種入力検証メソッドを通じて、データの整合性を保つことができる。
//・その他特筆事項
//- 入力検証をクラスにまとめることで、再利用性が高まり、コードの保守性が向上する。
//- ユーザーインターフェースとビジネスロジックを分離するために、入力検証は専用のクラスに委ねることが望ましい。
//////////////////////////

// InputValidator.cs 
using System;

namespace SalesManagement_SysDev.Classまとめ
{
    public static class InputValidator
    {
        /// <summary> 
        /// 入力が空でないか、かつ整数に変換できるかを確認する。 
        /// </summary> 
        /// <param name="input">検証対象の文字列</param> 
        /// <param name="empID">変換された社員ID</param> 
        /// <returns>入力が有効な場合はtrue、無効な場合はfalse。</returns> 
        public static bool IsValidEmployeeID(string input, out int empID)
        {
            return int.TryParse(input, out empID);
        }

        /// <summary> 
        /// 文字列が空でないかを確認する。 
        /// </summary> 
        /// <param name="input">検証対象の文字列</param> 
        /// <returns>空でない場合はtrue、空の場合はfalse。</returns> 
        public static bool IsNotEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
