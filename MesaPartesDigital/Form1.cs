using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MesaPartesDigital
{
    public partial class Form1 : Form
    {
        //creando listas
        private List<Expediente> expedientes = new List<Expediente>();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            colCodigo.DataPropertyName = "Codigo";
            colDni.DataPropertyName = "Dni";
            colNombre.DataPropertyName = "Nombre";
            colAsunto.DataPropertyName = "Asunto";
            colDescripcion.DataPropertyName = "Descripcion";
            colFecha.DataPropertyName = "Fecha";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string dni = txtDni.Text;
            string nombre = txtNombre.Text;
            string asunto = cboAsunto.Text;
            string descripcion= txtDescripcion.Text;
            string fecha = txtFecha.Text;

         
            Expediente expediente=new Expediente();

            expediente.Codigo = codigo;
            expediente.Dni = dni;
            expediente.Nombre = nombre;
            expediente.Asunto = asunto;
            expediente.Descripcion = descripcion;
            expediente.Fecha = fecha;

            expedientes.Add(expediente);

            //mostrar en tabla
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = expedientes;

            MessageBox.Show("Se Registro el EXPEDIENTE");
        }

       
    }
}
