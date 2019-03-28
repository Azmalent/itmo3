using System;

namespace RectangleMethod
{
    public static class Utils
    {
        public static void Swap(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }
    }
}
