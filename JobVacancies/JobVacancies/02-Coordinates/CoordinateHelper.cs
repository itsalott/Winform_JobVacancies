using JobVacancies._99_Helpers.Math.ItsaLott.Mathbuddy;
using System;

namespace JobVacancies._02_Coordinates
{
    public static class CoordinateHelper
    {
        // Notes for calculation (not perfect, google for help tomorrow ;) ):
        // Coordinate Utrecht            = 52.052699,    5.0719999
        // Pixels Utrecht                = 508.5,        670.5

        // Coordinate Arnhem             = 51.5848,      5.544
        // Pixels Arnhem                 = 734.5,        717.5

        // LongLati Utrecht -> Arnhem   = -0.467899,    0.4720001
        // Px Utrecht -> Arhem          = 226,          47

        // LongLati Source (0,0)        = 53.10547175,   -1.6615334414893

        /// <summary>
        /// This is the vector (in longitude latitude coordinates) that points to pixel coordinate 0,0 on the map (used in this application).
        /// </summary>
        public static readonly Vector2 LONG_LATI_CORRECTION_OFFSET = new Vector2(53.10547175, -1.6615334414893);

        /// <summary>
        /// Vector (1,1) in pixels, converted to longtitude latitude coordinates.
        /// </summary>
        public static readonly Vector2 LONG_LATI_SCALAR = new Vector2(-0.0020703495575, 0.0100425553191);

        /// <summary>
        /// Convert pixel coordinate to a longitude lattitude coordinate.
        /// </summary>
        /// <param name="pixelCoord">Coordinate on map, in pixels.</param>
        /// <param name="mapPosition">Translation of the map, in pixels.</param>
        public static Vector2 ToLongLatiCoord(this Vector2 pixelCoord, Vector2 mapPosition)
        {
            // remove map displacement, so position is relative to mapcoordinate (0,0) again
            pixelCoord -= mapPosition;

            return pixelCoord * LONG_LATI_SCALAR + LONG_LATI_CORRECTION_OFFSET;
        }

        /// <summary>
        /// Convert a longitude latitude coordinate to a pixel coordinate.
        /// </summary>
        /// <param name="longLatiCoord">Coordinate on map, in longitude lattitude.</param>
        /// <param name="mapPosition">Translation of the map, in pixels.</param>
        public static Vector2 ToPixelCoord(this Vector2 longLatiCoord, Vector2 mapPosition)
        {
            // longitude vector from origin
            longLatiCoord -= LONG_LATI_CORRECTION_OFFSET;

            return longLatiCoord / LONG_LATI_SCALAR + mapPosition;
        }
    }
}
