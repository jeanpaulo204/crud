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

namespace pizzaria1
{
    public partial class addcliente : Form
    {
        public addcliente()
        {
            InitializeComponent();

            txt_nome.Enabled = false;
            txt_sobrenome.Enabled = false;
            nb_cpf.Enabled = false;
            nb_telefone.Enabled = false;
            txt_bairro.Enabled = false;
            ch_p.Enabled = false;
            ch_b.Enabled = false;
            ch_pi.Enabled = false;
            nb_total.Enabled = false;
        }

        SqlConnection sqlcon = null;
        private string strCon = @"Data Source=DESKTOP-BLPPQK7\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string strSql = string.Empty;
        private SqlConnection sqlCon;


        private void Alterar()
        {
            strSql = "update pizza set nome=@Nome,sobrenome=@Sobrenome,cpf=@Cpf,email=@Telefone,bairro=@Bairro,portuguesa=@Portuguesa,Brócolis Com Parmesão=@Brócolis Com Parmesão, Pimentão com Queijo=@Pimentão com Queijo, total=@Total where nome=@Nome";

            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txt_nome.Text;
            comando.Parameters.Add("@Sobrenome", SqlDbType.VarChar).Value = txt_sobrenome.Text;
            comando.Parameters.Add("@Cpf", SqlDbType.VarChar).Value = nb_cpf.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = nb_telefone.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txt_bairro.Text;
            comando.Parameters.Add("@Portuguesa", SqlDbType.VarChar).Value = ch_p.Text;
            comando.Parameters.Add("@Brócolis Com Parmesão", SqlDbType.VarChar).Value = ch_b.Text;
            comando.Parameters.Add("@Pimentão com Queijo", SqlDbType.VarChar).Value = ch_pi.Text;
            comando.Parameters.Add("@Total", SqlDbType.VarChar).Value = nb_total.Text;

            if (txt_nome.Text == string.Empty || txt_sobrenome.Text == string.Empty || nb_cpf.Text == string.Empty || nb_telefone.Text == string.Empty || txt_bairro.Text == string.Empty || ch_p.Text == string.Empty || ch_b.Text == string.Empty || ch_pi.Text == string.Empty || nb_total.Text == string.Empty)
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS", "CAMPOS OBRIGATÓRIOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_pesquisar.Focus();
            }

            else
            {
                try
                {
                    if (MessageBox.Show("REALMENTE DESEJA ALTERAR OS DADOS", "MENSAGEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sqlCon.Open();
                        comando.ExecuteNonQuery();
                        MessageBox.Show("DADOS ALTERADOS COM SUCESSO", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    sqlCon.Close();
                    Close();
                    txt_pesquisar.Focus();
                }
            }
        }







        private void Deletar()
        {
            strSql = "delete from optname where nome=@Nome";

            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txt_nome.Text;

            if (txt_nome.Text == string.Empty || txt_sobrenome.Text == string.Empty || nb_cpf.Text == string.Empty || nb_telefone.Text == string.Empty || txt_bairro.Text == string.Empty || ch_p.Text == string.Empty || ch_b.Text == string.Empty || ch_pi.Text == string.Empty || nb_total.Text == string.Empty)
            {
                MessageBox.Show("SELECIONE O CADASTRO A SER EXCLUIDO", "CAMPOS VAZIOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_pesquisar.Focus();
            }

            else
            {
                try
                {
                    if (MessageBox.Show("REALMENTE DESEJA EXCLUIR O FUNCIONÁRIO", "MENSAGEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sqlCon.Open();
                        comando.ExecuteNonQuery();
                        MessageBox.Show("FUNCIONÁRIO EXCLUIDO COM SUCESSO!");
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    sqlCon.Close();
                    Close();
                    txt_pesquisar.Focus();
                }
            }
        }


        private void Adicionar()
        {
            strSql = "insert into optname  (Nome,Sobrenome,Cpf,Telefone,Bairro,Portuguesa,Brócolis Com Parmesão,Pimentão com Queijo,Total) values (@Nome,@Sobrenome,@Cpf,@Telefone,@Bairro,@Portuguesa,@Brócolis Com Parmesão,@Pimentão com Queijo,@Total)";

            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txt_nome.Text;
            comando.Parameters.Add("@Sobrenome", SqlDbType.VarChar).Value = txt_sobrenome.Text;
            comando.Parameters.Add("@Cpf", SqlDbType.VarChar).Value = nb_cpf.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = nb_telefone.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txt_bairro.Text;
            comando.Parameters.Add("@Portuguesa", SqlDbType.VarChar).Value = ch_p.Text;
            comando.Parameters.Add("@Brócolis Com Parmesão", SqlDbType.VarChar).Value = ch_b.Text;
            comando.Parameters.Add("@Pimentão com Queijo", SqlDbType.VarChar).Value = ch_pi.Text;
            comando.Parameters.Add("@Total", SqlDbType.VarChar).Value = nb_total.Text;

            if (txt_nome.Text == string.Empty || txt_sobrenome.Text == string.Empty || nb_cpf.Text == string.Empty || nb_telefone.Text == string.Empty || txt_bairro.Text == string.Empty || ch_p.Text == string.Empty || ch_b.Text == string.Empty || ch_pi.Text == string.Empty || nb_total.Text == string.Empty)
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS", "CAMPOS OBRIGATÓRIOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nome.Focus();
            }

            else
            {
                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();

                    MessageBox.Show("CADASTRO EFETUADO COM SUCESSO", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    sqlCon.Close();
                   Close();
                    txt_nome.Focus();
                }
            }
        }





        private void Pesquisar()
        {
            strSql = "select * from optname  where nome=@pesquisa";

            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txt_pesquisar.Text;

            try
            {
                if (txt_pesquisar.Text == string.Empty)
                {
                    MessageBox.Show("DIGITE O NOME DESEJADO", "CAMPO VAZIO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }

                sqlCon.Open();
                SqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows == false)
                {
                    throw new Exception("FUNCIONÁRIO NÃO CADASTRADO!");
                }

                dr.Read();

                txt_nome.Text = Convert.ToString(dr["nome"]);
                txt_sobrenome.Text = Convert.ToString(dr["sobrenome"]);
                nb_cpf.Text = Convert.ToString(dr["cpf"]);
                nb_telefone.Text = Convert.ToString(dr["telefone"]);
                txt_bairro.Text = Convert.ToString(dr["bairro"]);
               ch_p.Text = Convert.ToString(dr["portuguesa"]);
                ch_b.Text = Convert.ToString(dr["brocólis com parmesão"]);
                ch_pi.Text = Convert.ToString(dr["pimentão com queijo"]);
                nb_total.Text = Convert.ToString(dr["total"]);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                sqlCon.Close();
                txt_pesquisar.Clear();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void addcliente_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            txt_nome.Enabled = true;
            txt_sobrenome.Enabled = true;
            nb_cpf.Enabled = true;
            nb_telefone.Enabled = true;
            txt_bairro.Enabled = true;
            ch_p.Enabled = true;
            ch_b.Enabled = true;
            ch_pi.Enabled = true;
            nb_total.Enabled = true;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {


            Adicionar();

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_apagar_Click(object sender, EventArgs e)
        {
            Deletar();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            Alterar();
        }

        private void numb_cpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
