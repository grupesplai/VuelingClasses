using System;
using WindowsFormsApp1.ServiceReference1;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public event EventHandler refreshAlumnosAdd;
        Form1 form1;
        

        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Service1Client svc = new Service1Client("Http");
            Students newAlumno = new Students() {
                id = Guid.Parse(txtId.Text), name = txtNombre.Text , surname = txtApellidos.Text };
            svc.AddAlumno(newAlumno);

            refreshAlumnosAdd?.Invoke(this, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Service1Client svc = new Service1Client("Http");
            Students updAlumno = new Students() {
                id = Guid.Parse(txtId.Text), name = txtNombre.Text, surname = txtApellidos.Text   };
            svc.UpdateAlumno(updAlumno);

            refreshAlumnosAdd?.Invoke(this, e);
        }
    }
}
