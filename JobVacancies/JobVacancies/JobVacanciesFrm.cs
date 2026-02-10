using JobVacancies._00_Map;
using JobVacancies._01_PostalCodes;
using JobVacancies._02_Coordinates;
using JobVacancies._99_Helpers.Math.ItsaLott.Mathbuddy;
using JobVacancies.ItsaLott.Mathbuddy;
using System.Diagnostics;
using System.Windows.Forms;

namespace JobVacancies
{
    public partial class JobVacanciesFrm : Form
    {
        private MapBox map;
        private PostalCodeLocationManager locationManager;

        public JobVacanciesFrm()
        {
            // generated code, that handles the design of the form.
            InitializeComponent();
            
            // not generated code, for further setup, without getting in the way of the generated code.
            Setup();
        }

        private void Setup()
        {
            map = new MapBox(pictureBox, ClientSize);
            ClientSizeChanged += map.OnClientSizeChanged;

            CoordinateHelper.MapSize = map.ImageSize.ToVector2();
            locationManager = new PostalCodeLocationManager();
            
            // longitude latitude test:
            // Debug.WriteLine("Utrecht long lati: " + CoordinateHelper.ToLongLatiCoord(new Vector2(508, 670 ), Vector2.ZERO));
            // Debug.WriteLine("Maastricht long lati: " + CoordinateHelper.ToLongLatiCoord(new Vector2(676, 1239), Vector2.ZERO));
            // Debug.WriteLine("Groningen long lati: " + CoordinateHelper.ToLongLatiCoord(new Vector2(908, 158), Vector2.ZERO));
            // Debug.WriteLine("Amsterdam long lati: " + CoordinateHelper.ToLongLatiCoord(new Vector2(448, 545), Vector2.ZERO));
        }
    }
}
