using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moderno.cadastros
{
    public partial class FrmCadastroFornecedor : Form
    {
        readonly ConexaoModerno con = new ConexaoModerno();
        string sql;
        MySqlCommand cmd;
        const string MessageBoxTitle = "Cadastro de fornecedores";
        readonly Validacao validar = new Validacao();
        string cpfTemp;
        string id;
        public FrmCadastroFornecedor()
        {
            InitializeComponent();
        }

        private void FrmCadastroFornecedor_Load(object sender, EventArgs e)
        {
            Listar();
            LimpaCampos();
            DesabilitarCampos();
        }

        private bool ChecaCampos()
        {
            // tratar dados
            if (textNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNome.Text = string.Empty;
                textNome.Focus();
                return false;
            }
            if (textCnpj.Text == "  .   .   /    -" || textCnpj.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo Cpf", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCnpj.Focus();
                return false;
            }
            if (!validar.IsValid(textCnpj.Text))
            {
                textCnpj.Focus();
                return false;
            }
            if (textCadastro.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Data de Nascimento", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCadastro.Text = string.Empty;
                textCadastro.Focus();
                return false;
            }
            if (textTelefone.Text == "(  )      -" || textTelefone.Text.Length < 13)
            {
                MessageBox.Show("Preencha o campo Telefone", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textTelefone.Text = string.Empty;
                textTelefone.Focus();
                return false;
            }
            if (textEndereco.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Endereço", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEndereco.Text = string.Empty;
                textEndereco.Focus();
                return false;
            }

            return true;
        }

        private void LimpaCampos()
        {
            textNome.Text = string.Empty;
            textCnpj.Text = string.Empty;
            textEndereco.Text = string.Empty;
            textCadastro.Text = string.Empty;
            textTelefone.Text = string.Empty;
        }

        private void DesabilitarCampos()
        {
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;


            textNome.Enabled = false;
            textCnpj.Enabled = false;
            textEndereco.Enabled = false;
            textCadastro.Enabled = false;
            textEndereco.Enabled = false;
            textTelefone.Enabled = false;
        }

        private void HabilitarCampos()
        {
            textNome.Enabled = true;
            textCnpj.Enabled = true;
            textEndereco.Enabled = true;
            textCadastro.Enabled = true;
            textEndereco.Enabled = true;
            textTelefone.Enabled = true;
            btnNovo.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void Listar()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM fornecedores ORDER BY id_fornecedor ASC";
            cmd = new MySqlCommand(sql, con.conn);
            MySqlDataAdapter da = new MySqlDataAdapter
            {
                SelectCommand = cmd
            };
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGrid.DataSource = dt;
            con.FecharConexao();

            FormatarDG();
        }

        private void FormatarDG()
        {
            dataGrid.Columns[0].HeaderText = "Matricula";
            dataGrid.Columns[1].HeaderText = "Fornecedor";
            dataGrid.Columns[2].HeaderText = "CNPJ";
            dataGrid.Columns[3].HeaderText = "Tel.:";
            dataGrid.Columns[4].HeaderText = "Endereço";
            dataGrid.Columns[5].HeaderText = "Data de Inicio";
            dataGrid.Columns[0].Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ChecaCampos())
            {
                if (validar.CnpjExiste(textCnpj.Text, "fornecedores"))
                {
                    return;
                }
                DialogResult dr = MeuMsgBox.Mostrar($"Confirme os dados que serão salvos: \n" +
                                                    $"Nome: {textNome.Text}\n" +
                                                    $"CNPJ: {textCnpj.Text}\n" +
                                                    $"Data de Nascimento: {textCadastro.Text}\n" +
                                                    $"Telefone: {textTelefone.Text}\n" +
                                                    $"Endereço: {textEndereco.Text}\n",
                                                    MessageBoxTitle);

                if (dr != DialogResult.Yes)
                {
                    return;
                }
                con.AbrirConexao();
                sql = "INSERT INTO fornecedores(nome, cnpj, telefone, endereco, data_cadastro) VALUES(@nome, @cnpj, curDate(), @telefone, @endereco)";
                cmd = new MySqlCommand(sql, con.conn);

                cmd.Parameters.AddWithValue("@nome", textNome.Text);
                cmd.Parameters.AddWithValue("@cnpj", textCnpj.Text);
                cmd.Parameters.AddWithValue("@telefone", textTelefone.Text);
                cmd.Parameters.AddWithValue("@endereco", textEndereco.Text);
                cmd.Parameters.AddWithValue("@data_cadastro", textCadastro.Text);

                cmd.ExecuteNonQuery();
                con.FecharConexao();

                Listar();

                MessageBox.Show("Registro salvo com sucesso!", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpaCampos();
                DesabilitarCampos();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            HabilitarCampos();
            btnSalvar.Enabled = true;
            textNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            Listar();
            DesabilitarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ChecaCampos())
            {
                string id = dataGrid.CurrentRow.Cells[0].Value.ToString();

                con.AbrirConexao();
                sql = "UPDATE fornecedores " +
                      "SET nome = @nome, cnpj = @cnpj, telefone = @telefone, endereco = @endereco, data_cadastro = @data_cadastro " +
                      $"WHERE id_fornecedor = {id}";
                cmd = new MySqlCommand(sql, con.conn);

                cmd.Parameters.AddWithValue("@nome", textNome.Text);
                cmd.Parameters.AddWithValue("@cnpj", textCnpj.Text);
                cmd.Parameters.AddWithValue("@telefone", textTelefone.Text);
                cmd.Parameters.AddWithValue("@endereco", textEndereco.Text);
                cmd.Parameters.AddWithValue("@data_cadastro", textCadastro.Text);

                if (cpfTemp != textCnpj.Text)
                {
                    MessageBox.Show("CNPJ não pode ser alterado!", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmd.ExecuteNonQuery();
                con.FecharConexao();
                Listar();
                MessageBox.Show("Registro atualizado com sucesso!", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpaCampos();
                DesabilitarCampos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult dr = MeuMsgBox.Mostrar("Tem certeza que deseja remover registro ?",
                                                MessageBoxTitle);

            if (dr != DialogResult.Yes)
            {
                return;
            }

            string id = dataGrid.CurrentRow.Cells[0].Value.ToString();

            con.AbrirConexao();
            sql = "DELETE FROM fornecedores " +
                    $"WHERE id_fornecedor = {id}";
            cmd = new MySqlCommand(sql, con.conn);

            cmd.ExecuteNonQuery();
            con.FecharConexao();
            Listar();

            MessageBox.Show("Registro removido com sucesso!",
                            MessageBoxTitle,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            LimpaCampos();
            DesabilitarCampos();
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                textNome.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
                textCnpj.Text = dataGrid.CurrentRow.Cells[2].Value.ToString();
                textCadastro.Text = dataGrid.CurrentRow.Cells[3].Value.ToString();
                textTelefone.Text = dataGrid.CurrentRow.Cells[4].Value.ToString();
                textEndereco.Text = dataGrid.CurrentRow.Cells[5].Value.ToString();
                btnEditar.Enabled = true;
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = true;
                cpfTemp = textCnpj.Text;
                HabilitarCampos();
            }
        }
    }
}
