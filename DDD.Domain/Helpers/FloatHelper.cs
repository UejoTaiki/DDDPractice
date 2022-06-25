using System;

namespace DDDPractice.Common
{
    public static class FloatHelper
    {
        /// <summary>
        /// 小数点以下を指定桁数で四捨五入する
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPoint"></param>
        /// <returns></returns>
        public static String RoundString(this float value, int decimalPoint)
        {
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString("F" + decimalPoint);
        }
    }
}
