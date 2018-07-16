using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CobalcoWebApiClient
{
    public partial class Form1 : Form
    {
        private DataGridView dataGrid = new DataGridView();
        HttpApiController controller;


        public Form1()
        {
            InitializeComponent();
            dataGrid.AutoGenerateColumns = true;
            controller = new HttpApiController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<AlumnoModel> alumnoList = new List<AlumnoModel>();
            alumnoList = controller.GetCall().Result;
            dataGrid.DataSource = alumnoList;
            dataGrid.Refresh();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
