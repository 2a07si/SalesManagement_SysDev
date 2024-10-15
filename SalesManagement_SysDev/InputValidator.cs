// InputValidator.cs
using System;

namespace SalesManagement_SysDev
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
