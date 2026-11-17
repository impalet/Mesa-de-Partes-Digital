using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace MesaPartesDigital
{
    public partial class Form1 : Form
    {
        //creando listas
        private List<Expediente> expedientes = new List<Expediente>();
        //ruta donde se guardara los archivos
        private string rutaArchivo = Path.Combine(Application.StartupPath, "expedientes.txt");
        private Expediente expedienteSeleccionado = null;
        public Form1()
        {
            InitializeComponent();
            cboAsunto.Items.Clear();
            lblFechaa.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            cboAsunto.Items.Add("Solicitud");
            cboAsunto.Items.Add("Reclamo");
            cboAsunto.Items.Add("Consulta");
            cboAsunto.Items.Add("Denuncia");
            cboAsunto.Items.Add("Otros");

            dataGridView1.AutoGenerateColumns = false;

            colCodigo.DataPropertyName = "Codigo";
            colDni.DataPropertyName = "Dni";
            colNombre.DataPropertyName = "Nombre";
            colAsunto.DataPropertyName = "Asunto";
            colDescripcion.DataPropertyName = "Descripcion";
            colFecha.DataPropertyName = "Fecha";
            CargarExpedientes();
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
            
            //recorre cada expediente en busqueda de codigo ya existente
            foreach (Expediente item in expedientes) 
            {
                if (item.Codigo == txtCodigo.Text)
                {
                    MessageBox.Show("El código de expediente YA EXISTE.");
                    return;
                }
            }
            string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblFechaa.Text = fecha;


            Expediente expediente=new Expediente();
         
            
            expediente.Codigo = codigo;
            expediente.Dni = dni;
            expediente.Nombre = nombre;
            expediente.Asunto = asunto;
            expediente.Descripcion = descripcion;
            expediente.Fecha = fecha;

            expedientes.Add(expediente);
            GuardarExpedientes();

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
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            expedienteSeleccionado=null;
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { 
            string codigoBuscado = txtCodigo.Text;

            foreach (Expediente item in expedientes)
            {
                if (item.Codigo == codigoBuscado)
                {
                    expedienteSeleccionado = item;
                    txtDni.Text = item.Dni;
                    txtNombre.Text=item.Nombre;
                    cboAsunto.Text = item.Asunto;
                    txtDescripcion.Text=item.Descripcion;
                    lblFechaa.Text = item.Fecha;

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (expedienteSeleccionado == null)
            {
                MessageBox.Show("Primero busque un expediente.");
                return;
            }

            if (txtDni.Text == "" || txtNombre.Text == "")
            {
                MessageBox.Show("Complete el DNI y el nombre.");
                return;
            }

            if (txtDni.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos.");
                return;
            }

            if (!long.TryParse(txtDni.Text, out _))
            {
                MessageBox.Show("El DNI debe contener solo números.");
                return;
            }

            expedienteSeleccionado.Dni = txtDni.Text;
            expedienteSeleccionado.Nombre = txtNombre.Text;
            expedienteSeleccionado.Asunto = cboAsunto.Text;
            expedienteSeleccionado.Descripcion = txtDescripcion.Text;
            

            GuardarExpedientes();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = expedientes;

            MessageBox.Show("Expediente actualizado correctamente.");

            expedienteSeleccionado = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (expedienteSeleccionado == null)
            {
                MessageBox.Show("Primero busque un expediente.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar este expediente?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta == DialogResult.Yes)
            {
                expedientes.Remove(expedienteSeleccionado);
                GuardarExpedientes();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = expedientes;

                expedienteSeleccionado = null;

                MessageBox.Show("Expediente eliminado correctamente.");
            }
        }

        private void GuardarExpedientes()
        {
            using (StreamWriter escritor = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
            {
                foreach (Expediente item in expedientes)
                {
                    string linea = item.Codigo + "|" +
                                   item.Dni + "|" +
                                   item.Nombre + "|" +
                                   item.Asunto + "|" +
                                   item.Descripcion + "|" +
                                   item.Fecha;

                    escritor.WriteLine(linea);
                }
            }
        }

        private void CargarExpedientes()
        {
            expedientes.Clear();

            if (File.Exists(rutaArchivo))
            {
                using (StreamReader lector = new StreamReader(rutaArchivo, Encoding.UTF8))
                {
                    string linea;

                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] datos = linea.Split('|');

                        if (datos.Length == 6)
                        {
                            Expediente expediente = new Expediente();

                            expediente.Codigo = datos[0];
                            expediente.Dni = datos[1];
                            expediente.Nombre = datos[2];
                            expediente.Asunto = datos[3];
                            expediente.Descripcion = datos[4];
                            expediente.Fecha = datos[5];

                            expedientes.Add(expediente);
                        }
                    }
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = expedientes;
        }


    }

}
