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
            //validar campos vacios
            if (txtCodigo.Text == "" || txtDni.Text==""|| txtNombre.Text=="")
                {
                    MessageBox.Show("Complete el Codigo, DNI, y Nombre. ");
                    return;
                }
            //validar tamaño de dni
            if (txtDni.Text.Length != 8)
            {

                MessageBox.Show("El DNI debe tener 8 dígitos. ");
                return;
            }

            //valida solo numeros
            if (!long.TryParse(txtDni.Text, out _))
            {
                MessageBox.Show("El DNI debe contener solo números. ");
                return;
            }

            string codigo = txtCodigo.Text;
            string dni = txtDni.Text;
            string nombre = txtNombre.Text;
            string asunto = cboAsunto.Text;
            string descripcion= txtDescripcion.Text;
            string fecha = txtFecha.Text;
            //recorre cada expediente en busqueda de codigo ya existente
            foreach (Expediente item in expedientes) 
            {
                if (item.Codigo == txtCodigo.Text)
                {
                    MessageBox.Show("El código de expediente YA EXISTE.");
                    return;
                }
            }

         
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

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            //metodos limpiar casilla
            txtCodigo.Clear();
            txtDni.Clear();
            txtNombre.Clear();
            cboAsunto.SelectedIndex = -1;
            txtDescripcion.Clear();
            txtFecha.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { 
            string codigoBuscado = txtCodigo.Text;

            foreach (Expediente item in expedientes)
            {
                if (item.Codigo == codigoBuscado)
                {
                    txtDni.Text = item.Dni;
                    txtNombre.Text=item.Nombre;
                    cboAsunto.Text = item.Asunto;
                    txtFecha.Text = item.Fecha;

                    MessageBox.Show("Expediente cargando correctamente. ");
                    return;
                }
            }

            MessageBox.Show("No se encontro el expediente. ");
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string codigoBuscado = txtBusqueda.Text;

            foreach (Expediente item in expedientes)
            {
                if (item.Codigo == codigoBuscado)
                {
                    MessageBox.Show("Expediente encontrado: " + item.Nombre);
                    return;
                }
            }

            MessageBox.Show("No se encontro el expediente. ");

        }
    }
}
