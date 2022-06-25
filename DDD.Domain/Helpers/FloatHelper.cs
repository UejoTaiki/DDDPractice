using System;

namespace DDDPractice.Common
{
    public static class FloatHelper
    {
        public static String RoundString(float value, int decimalPoint)
        {
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString("F" + decimalPoint);
        }
    }
}
