using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Persona : Form
    {
        SqlConnection conn;
        public Persona(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void Persona_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                if(conn.State == ConnectionState.Open) {
                    String sql = "SELECT *FROM tbl_usuario";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader r = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(r);
                    dgvListado.DataSource = dt;
                    dgvListado.Refresh();
                }
                else
                {
                    MessageBox.Show("La conexion esta cerrada");
                }

            }catch (Exception ex)
            {
                MessageBox.Show("Error al listar personas \n" + ex.ToString());
            }
        }
    }
}
