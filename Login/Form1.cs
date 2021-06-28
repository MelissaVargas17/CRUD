using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class LoginMante : Form
    {

        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();
        public LoginMante()
        {
            InitializeComponent();
        }

        void Mantenimiento(string accion)
        {
            objent.identificacion = labelIdenti.Text;
            objent.nombre = labelNombre.Text;
            objent.edad = Convert.ToInt32(labelTelefono.Text);
            objent.accion = accion;
            string men = objneg.N_mantenimiento_clientes(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar()
        {
            labelIdenti.Text = "";
            labelNombre.Text = "";
            labelEdad.Text = "";
            labelTelefono.Text = "";
            labelNomBusc.Text = "";
            dataGridViewListar.DataSource = objneg.N_listar_clientes();
        }

        private void LoginMante_Load(object sender, EventArgs e)
        {
            dataGridViewListar.DataSource = objneg.N_listar_clientes();
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(labelIdenti.Text == "")
            {
                if(MessageBox.Show("¿Deseas registrar a " + labelNombre.Text + "?", "Mensaje", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(labelIdenti.Text != "")
            {
                if(MessageBox.Show("¿Deseas modificar a " + labelNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(labelIdenti.Text != "")
            {
                if(MessageBox.Show("¿Deseas eliminar a " + labelNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void labelNomBusc_TextChanged(object sender, EventArgs e)
        {
            if (labelNomBusc.Text != "")
            {
                objent.nombre = labelNomBusc.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_clientes(objent);
                dataGridViewListar.DataSource = dt;
            }
            else
            {
                dataGridViewListar.DataSource = objneg.N_listar_clientes();
            }
        }

        private void dataGridViewListar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridViewListar.CurrentCell.RowIndex;

            labelIdenti.Text = dataGridViewListar[0, fila].Value.ToString();
            labelNombre.Text = dataGridViewListar[1, fila].Value.ToString();
            labelEdad.Text = dataGridViewListar[2, fila].Value.ToString();
            labelTelefono.Text = dataGridViewListar[3, fila].Value.ToString();
        }
    }
}
