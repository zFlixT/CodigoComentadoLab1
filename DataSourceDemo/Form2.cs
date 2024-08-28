using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    public partial class Form2 : Form
    {
        // Constructor de la clase Form2.
        public Form2()
        {
            InitializeComponent();
        }
        1
         // Evento que se dispara al hacer clic en el botón de guardar del BindingNavigator (una barra de navegación para datos).
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        // Evento que se dispara cuando el formulario Form2 se carga.
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindDataSet.Customers' Puede moverla o quitarla según sea necesario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

        }


        private void cajaTextoID_Click(object sender, EventArgs e)
        {
            
        }

        // Evento que se dispara cuando se presiona una tecla en el control 'cajaTextoID'.
        private void cajaTextoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es Enter (char 13 representa Enter).
            if (e.KeyChar == (char)13) {
              var index =  customersBindingSource.Find("customerID", cajaTextoID);
                if (index > -1)
                {
                    // Si se encuentra un registro (índice mayor a -1), se posiciona en ese registro.
                    customersBindingSource.Position = index;
                    return;
                }
                else {
                    // Si no se encuentra el registro, muestra un mensaje de que el elemento no fue encontrado.
                    MessageBox.Show("Elemento no encontrado");
                }
            };
        }
    }
}
