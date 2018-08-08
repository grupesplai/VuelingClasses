using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Edit : Form
    {
        Form1 form1;
        public Edit()
        {
            InitializeComponent();
        }
        public Edit(Form1 owner)
        {
            InitializeComponent();
            form1 = owner;
            this.FormClosing += new FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.getAll();
        }

        public int id
        {
            get { return Convert.ToInt32(txtId.Text); }
            set { txtId.Text = value.ToString(); }
        }
        public string nombre
        {
            get { return txtNombre.Text; }
            set { txtNombre.Text = value; }
        }
        public string apellidos
        {
            get { return txtApellidos.Text; }
            set { txtApellidos.Text = value; }
        }
    }
}
