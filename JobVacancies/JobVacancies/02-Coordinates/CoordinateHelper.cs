using JobVacancies._99_Helpers.Math.ItsaLott.Mathbuddy;
using JobVacancies.ItsaLott.Mathbuddy;
using System;

namespace JobVacancies._02_Coordinates
{
    public static class CoordinateHelper
    {
        
        private static readonly Vector2 LONG_LATI_MIN = new Vector2(3.1, 53.6);
        private static readonly Vector2 LONG_LATI_MAX = new Vector2(7.1, 50.4);

        public static Vector2 MapSize { get; set; }

        /// <summary>
        /// Convert pixel coordinate to a longitude lattitude coordinate.
        /// </summary>
        /// <param name="pixelCoord">Coordinate on map, in pixels.</param>
        /// <param name="mapPosition">Translation of the map, in pixels.</param>
        public static Vector2 ToLongLatiCoord(this Vector2 pixelCoord, Vector2 mapPosition)
        {
            // remove map displacement, so position is relative to mapcoordinate (0,0) again
            pixelCoord -= mapPosition;
            
            Vector2 t = pixelCoord / MapSize;

            return Vector2.Lerp(LONG_LATI_MIN, LONG_LATI_MAX, t);
        }

        /// <summary>
        /// Convert a longitude latitude coordinate to a pixel coordinate.
        /// </summary>
        /// <param name="longLatiCoord">Coordinate on map, in longitude lattitude.</param>
        /// <param name="mapPosition">Translation of the map, in pixels.</param>
        public static Vector2 ToPixelCoord(this Vector2 longLatiCoord, Vector2 mapPosition)
        {
            // convert to vector from origin
            longLatiCoord -= LONG_LATI_MIN;

            // get t value, based on vector length
            Vector2 t = longLatiCoord / (LONG_LATI_MAX - LONG_LATI_MIN);

            return Vector2.Lerp(Vector2.ZERO, MapSize, t);
        }
    }
}
