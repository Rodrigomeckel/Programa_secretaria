using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace app_secretária
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DNBNVLS\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btn_pasquisar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-DNBNVLS\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string pesquisar = "SELECT * FROM CADASTRO WHERE cpf = '"+mtxb_cpf_pesquisar.Text+"'";
            cmd = new SqlCommand(pesquisar, con);

            try
            {
                if (mtxb_cpf_pesquisar.Text == string.Empty)
                {
                    MessageBox.Show("VOCÊ PRESCISA DIGITAR O CPF !!", "MESAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == false)
                {

                    throw new Exception("ESTE CPF NÃO ESTÁ CADASTRADO!!");


                }




                dr.Read();

                txb_username_pesquisar.Text = Convert.ToString(dr["nome_completo"]);
                mtxb_dta_nasc.Text = Convert.ToString(dr["dta_nasc"]);
                mtxb_telefone_pesquisar.Text = Convert.ToString(dr["telefone"]);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                con.Close();
            }
        }
    }
}
