using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_APROBADO_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private HuespedBLL huespedBLL = new HuespedBLL();
        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarDGVHuesped();
        }
        public void ActualizarDGVHuesped()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = huespedBLL.ListarTodos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Huesped huesped = new Huesped { Email = "fafas@gmail.com", NombreCompleto = "asfa", Pasaporte = "1234" };
                var respueta = huespedBLL.Agregar(huesped);
                if (!respueta) throw new Exception("Ocurrio un error al agregar");
                MessageBox.Show("Se agrego correctamente");
                ActualizarDGVHuesped();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                var huesped = dataGridView1.CurrentRow.DataBoundItem as Huesped;
                var respueta = huespedBLL.Eliminar(huesped.Id);
                if (!respueta) throw new Exception("Ocurrio un error al eliminar");
                MessageBox.Show("Se elimino correctamente");
                ActualizarDGVHuesped();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
        }

        private void btnModifcar_Click(object sender, EventArgs e)
        {
            try
            {
                var huesped = dataGridView1.CurrentRow.DataBoundItem as Huesped;

                huesped.NombreCompleto = "maxi";
                huesped.Pasaporte = "afg-23123";
                huesped.Email = "jiji@gmail";

                var respueta = huespedBLL.Modificar(huesped);
                if (!respueta) throw new Exception("Ocurrio un error al modificar");
                MessageBox.Show("Se modifico correctamente");
                ActualizarDGVHuesped();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                var huesped = dataGridView1.CurrentRow.DataBoundItem as Huesped;
                SaveFileDialog svg = new SaveFileDialog();
                if(svg.ShowDialog() == DialogResult.OK)
                {
                    huespedBLL.Exportar(svg.FileName, huesped);
                    MessageBox.Show("Exportado correctamente ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO Exportado");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Habitacion habitacion = new Habitacion {Numero = 104, PrecioBase = "231", Tipo = "Simple" };
                          }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
        }
    }
}
