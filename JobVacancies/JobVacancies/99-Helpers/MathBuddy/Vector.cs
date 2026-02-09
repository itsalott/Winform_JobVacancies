namespace JobVacancies._99_Helpers.Math
{
    namespace ItsaLott.Mathbuddy
    {
        public struct Vector2
        {
            public static readonly Vector2 ZERO = new Vector2(0, 0);

            public double Magnitude {
                get { 
                    if (!magnitude.HasValue)
                    {
                        magnitude = System.Math.Sqrt(System.Math.Pow(x, 2) + System.Math.Pow(y, 2));
                    }
                    return magnitude.Value;
                }
            }
            private double? magnitude;

            public double x;
            public double y;

            public Vector2(double x, double y)
            {
                this.x = x;
                this.y = y;
                magnitude = null;
            }

            public Vector2(int x, int y)
            {
                this.x = (float)x;
                this.y = (float)y;
                magnitude = null;
            }

            public override string ToString()
            {
                return $"({x},{y})";
            }

            #region OPERATORS
            public static Vector2 operator +(Vector2 left, Vector2 right)
            {
                return new Vector2(left.x + right.x, left.y + right.y);
            }

            public static Vector2 operator -(Vector2 left, Vector2 right)
            {
                return new Vector2(left.x - right.x, left.y - right.y);
            }

            public static Vector2 operator *(Vector2 left, Vector2 right)
            {
                return new Vector2(left.x * right.x, left.y * right.y);
            }

            public static Vector2 operator /(Vector2 left, Vector2 right)
            {
                return new Vector2(left.x / right.x, left.y / right.y);
            }
            #endregion
        }
    }
}
