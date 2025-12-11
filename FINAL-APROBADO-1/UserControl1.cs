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
    public partial class UserControl1 : UserControl, IObservador
    {
        public UserControl1()
        {
            InitializeComponent();
            huespedBLL.Suscribir(this);
        }
        private HuespedBLL huespedBLL = new HuespedBLL();
        public void Actualizar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = huespedBLL.ListarTodos();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    huespedBLL.Importar(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
                throw;
            }
        }
    }
}
