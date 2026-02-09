using JobVacancies._99_Helpers.Math.ItsaLott.Mathbuddy;
using System;
using System.Diagnostics;
using System.Drawing;

namespace JobVacancies
{
    namespace ItsaLott.Mathbuddy
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

            public static Point ToPoint(this Vector2 vector, bool round = false)
            {
                if (round)
                    return new Point((int)Math.Round(vector.x), (int)Math.Round(vector.y));

                return new Point((int)vector.x, (int)vector.y);
            }

            public static Vector2 ToVector2(this Point point)
            {
                return new Vector2(point.X, point.Y);
            }
        }
    }
}
