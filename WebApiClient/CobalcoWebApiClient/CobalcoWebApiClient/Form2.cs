using CobalcoWebApiClient.WebApiJson;
using System.Windows.Forms;

namespace CobalcoWebApiClient
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            //var url = "https://openexchangerates.org/api/latest.json?app_id=YOUR_APP_ID";
            //var currencyRates = SerializedJson.ToSerializeJson<CurrencyRates>(url);
            
        }

        private void submit_Click(object sender, System.EventArgs e)
        {
            AlumnoModel alumno = new AlumnoModel(textBox1.Text, textBox2.Text, textBox3.Text);

            string message = HttpApiController.AddAlumno(alumno);
            label4.Text = message;
        }
    }
}
