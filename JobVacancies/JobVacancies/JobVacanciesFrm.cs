using JobVacancies._00_Map;
using JobVacancies._01_PostalCodes;
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
            locationManager = new PostalCodeLocationManager();
        }
    }
}
