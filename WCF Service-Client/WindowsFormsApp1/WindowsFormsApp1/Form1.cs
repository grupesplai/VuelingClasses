using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.ServiceReference1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.refreshAlumnosAdd += new EventHandler(btnHttp_Click);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            form2.Show();
        }

        public void btnHttp_Click(object sender, EventArgs e)
        {
            getAll();
        }
        public void getAll()
        {
            Service1Client svcH = new Service1Client("Http");
            dataGridView1.DataSource = svcH.GetAll();
            OptionsBtn(dataGridView1);
        }

        private void btnTcp_Click(object sender, EventArgs e)
        {
            Service1Client svcT = new Service1Client("Tcp");
            dataGridView1.DataSource = svcT.GetAll();
        }

        private void OptionsBtn(DataGridView grid)
        {
            DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            Editlink.UseColumnTextForLinkValue = true;
            Editlink.HeaderText = "Edit";
            Editlink.DataPropertyName = "lnkColumn";
            Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            Editlink.Text = "Edit";
            grid.Columns.Add(Editlink);

            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "delete";
            Deletelink.DataPropertyName = "lnkColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            grid.Columns.Add(Deletelink);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                Edit editForm = new Edit(this);
                editForm.id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                editForm.nombre = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                editForm.apellidos = dataGridView1.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();

                editForm.Show();
                dataGridView1.Refresh();
            }
            if (e.ColumnIndex == 1)
            {
                Guid id = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                Service1Client svcH = new Service1Client("Http");
                svcH.DeleteAlumno(id);
                getAll();
            }
        }
    }
}
