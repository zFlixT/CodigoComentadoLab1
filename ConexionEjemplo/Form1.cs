using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatosLayer;
using System.Net;
using System.Reflection;


namespace ConexionEjemplo
{
    public partial class Form1 : Form
    {
        // Instancia de la clase CustomerRepository para interactuar con la base de datos
        CustomerRepository customerRepository = new CustomerRepository();

        // Constructor de la clase Form1
        public Form1()
        {
            InitializeComponent();
        }

        // Evento que se dispara al hacer clic en el botón 'Cargar'
        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Obtiene todos los clientes usando el repositorio y los asigna como fuente de datos del DataGridView
            var Customers = customerRepository.ObtenerTodos();
            dataGrid.DataSource = Customers;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // var filtro = Customers.FindAll( X => X.CompanyName.StartsWith(tbFiltro.Text));
           // dataGrid.DataSource = filtro;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
         /*  DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
          DatosLayer.DataBase.ConnectionTimeout = 30;

          string cadenaConexion = DatosLayer.DataBase.ConnectionString;
            var conxion = DatosLayer.DataBase.GetSqlConnection();
         */
        }

        // Evento que se dispara al hacer clic en el botón 'Buscar'
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text);
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text= cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        // Evento que se dispara al hacer clic en el botón 'Insertar'
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var resultado = 0;
      ;

            var nuevoCliente = ObtenerNuevoCliente();


            // hayNull= validarCampoNull(nuevoCliente) ? true : false ;

            /*  if (tboxCustomerID.Text != "" || 
                  tboxCompanyName.Text !="" ||
                  tboxContacName.Text != "" ||
                  tboxContacName.Text != "" ||
                  tboxAddress.Text != ""    ||
                  tboxCity.Text != "")
              {
                  resultado = customerRepository.InsertarCliente(nuevoCliente);
                  MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
              }
              else {
                  MessageBox.Show("Debe completar los campos por favor");
              }

              */

            /*
            if (nuevoCliente.CustomerID == "") {
                MessageBox.Show("El Id en el usuario debe de completarse");
               return;    
            }

            if (nuevoCliente.ContactName == "")
            {
                MessageBox.Show("El nombre de usuario debe de completarse");
                return;
            }
            
            if (nuevoCliente.ContactTitle == "")
            {
                MessageBox.Show("El contacto de usuario debe de completarse");
                return;
            }
            if (nuevoCliente.Address == "")
            {
                MessageBox.Show("la direccion de usuario debe de completarse");
                return;
            }
            if (nuevoCliente.City == "")
            {
                MessageBox.Show("La ciudad de usuario debe de completarse");
                return;
            }

            */

            // Inserta el nuevo cliente si no hay campos nulos.
            if (validarCampoNull(nuevoCliente) == false)
            {
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
            }
            else {
                MessageBox.Show("Debe completar los campos por favor");
            }
        }

        // Método para validar si algún campo del objeto es nulo
        // si encautnra un null enviara true de lo caontrario false
        public Boolean validarCampoNull(Object objeto) {

            foreach (PropertyInfo property in objeto.GetType().GetProperties()) {
                object value = property.GetValue(objeto, null);
                if ((string)value == "") {
                    return true;
                }
            }
            return false;
        }
      
        private void label5_Click(object sender, EventArgs e)
        {

        }

        // Evento que se dispara al hacer clic en el botón 'Modificar'
        private void btModificar_Click(object sender, EventArgs e)
        {
            var actualizarCliente = ObtenerNuevoCliente();
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente);
            MessageBox.Show($"Filas actualizadas = {actualizadas}");
        }

        // Método para obtener un nuevo cliente a partir de los valores de los TextBox
        private Customers ObtenerNuevoCliente() {

            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContacName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };

            return nuevoCliente;
        }

        // Evento que se dispara al hacer clic en el botón 'Eliminar'
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Evento que se dispara al hacer clic en el botón 'Eliminar'
            int elimindas = customerRepository.EliminarCliente(tboxCustomerID.Text);
            MessageBox.Show("Filas eliminadas = " + elimindas);
        }
    }
}
