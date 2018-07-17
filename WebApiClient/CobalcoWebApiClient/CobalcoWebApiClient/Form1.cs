using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CobalcoWebApiClient
{
    public partial class Form1 : Form
    {
      
        HttpApiController controller;
        public Form1()
        {
            InitializeComponent();
            dataGridAlumnos.AutoGenerateColumns = true;
            controller = new HttpApiController();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            List<AlumnoModel> alumnoList = new List<AlumnoModel>();
            alumnoList = controller.GetCall().Result;
            dataGridAlumnos.DataSource = alumnoList;
            dataGridAlumnos.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form2 frm = new Form2();
            bool asd = HttpApiController.Delete(2);
            frm.Show();
        }
    }
}
