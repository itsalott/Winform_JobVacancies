using System;
using System.Diagnostics;

namespace JobVacancies
{
    public static class MathBuddy
    {
        // No clamp in .Net frameworks :(, so I copied Microsofts implementation.

        /// <summary>
        /// Clamps value between provided min and max value.
        /// </summary>
        /// <param name="value">Value that will be clamped.</param>
        /// <param name="min">Minimum value (inclusive).</param>
        /// <param name="max">Maximum value (inclusive).</param>
        public static int Clamp(int value, int min, int max)
        {
            if (min > max)
            {
                throw new Exception("Min value cannot be bigger than max!");
            }

            if (value < min)
            {
                Debug.WriteLine("Miauw min");
                return min;
            }
            else if (value > max)
            {
                Debug.WriteLine("Miauw max");
                return max;
            }

            return value;
        }
    }
}
