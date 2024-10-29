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
    public partial class FrmCadastroCliente : Form
    {
        readonly ConexaoModerno con = new ConexaoModerno();
        string sql;
        MySqlCommand cmd;
        const string MessageBoxTitle = "Cadastro de clientes";
        readonly Validacao validar = new Validacao();
        string cpfTemp;
        string id;
        public FrmCadastroCliente()
        {
            InitializeComponent();
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
            if (textCpf.Text == "   .   .   -" || textCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo Cpf", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCpf.Focus();
                return false;
            }
            if (!validar.IsValid(textCpf.Text))
            {
                textCpf.Focus();
                return false;
            }
            if (textNascimento.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Data de Nascimento", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNascimento.Text = string.Empty;
                textNascimento.Focus();
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
            textCpf.Text = string.Empty;
            textEndereco.Text = string.Empty;
            textNascimento.Text = string.Empty;
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
            textCpf.Enabled = false;
            textEndereco.Enabled = false;
            textNascimento.Enabled = false;
            textEndereco.Enabled = false;
            textTelefone.Enabled = false;
        }

        private void HabilitarCampos()
        {
            textNome.Enabled = true;
            textCpf.Enabled = true;
            textEndereco.Enabled = true;
            textNascimento.Enabled = true;
            textEndereco.Enabled = true;
            textTelefone.Enabled = true;
            btnNovo.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void Listar()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM clientes ORDER BY matricula ASC";
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
            dataGrid.Columns[1].HeaderText = "Colaborador";
            dataGrid.Columns[2].HeaderText = "CPF";
            dataGrid.Columns[3].HeaderText = "Aniversario";
            dataGrid.Columns[4].HeaderText = "Tel.:";
            dataGrid.Columns[5].HeaderText = "Endereço";
            dataGrid.Columns[6].HeaderText = "Cliente desde";
            dataGrid.Columns[0].Visible = false;
        }
        private void FrmCadastroCliente_Load(object sender, EventArgs e)
        {
            LimpaCampos();
            Listar();
            DesabilitarCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            HabilitarCampos();
            btnSalvar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ChecaCampos())
            {
                if (validar.CpfExiste(textCpf.Text, "clientes"))
                {
                    return;
                }
                DialogResult dr = MeuMsgBox.Mostrar($"Confirme os dados que serão salvos: \n" +
                                  $"Nome: {textNome.Text}\n" +
                                  $"CPF: {textCpf.Text}\n" +
                                  $"Data de Nascimento: {textNascimento.Text}\n" +
                                  $"Telefone: {textTelefone.Text}\n" +
                                  $"Endereço: {textEndereco.Text}\n", MessageBoxTitle);

                if (dr != DialogResult.Yes)
                {
                    return;
                }

                con.AbrirConexao();
                sql = "INSERT INTO clientes(nome, cpf, data_nascimento, telefone, endereco, data_cadastro) VALUES(@nome, @cpf, @data_nascimento, @telefone, @endereco, curDate())";
                cmd = new MySqlCommand(sql, con.conn);

                cmd.Parameters.AddWithValue("@nome", textNome.Text);
                cmd.Parameters.AddWithValue("@cpf", textCpf.Text);
                cmd.Parameters.AddWithValue("@data_nascimento", textNascimento.Text);
                cmd.Parameters.AddWithValue("@telefone", textTelefone.Text);
                cmd.Parameters.AddWithValue("@endereco", textEndereco.Text);

                cmd.ExecuteNonQuery();
                con.FecharConexao();

                Listar();

                MessageBox.Show("Registro salvo com sucesso!", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            id = dataGrid.CurrentRow.Cells[0].Value.ToString();

            con.AbrirConexao();
            sql = "DELETE FROM clientes " +
                  $"WHERE matricula = {id}";
            cmd = new MySqlCommand(sql, con.conn);

            cmd.Parameters.AddWithValue("@nome", textNome.Text);
            cmd.Parameters.AddWithValue("@cpf", textCpf.Text);
            cmd.Parameters.AddWithValue("@data_nascimento", textNascimento.Text);
            cmd.Parameters.AddWithValue("@telefone", textTelefone.Text);
            cmd.Parameters.AddWithValue("@endereco", textEndereco.Text);

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ChecaCampos())
            {
                id = dataGrid.CurrentRow.Cells[0].Value.ToString();

                con.AbrirConexao();
                sql = "UPDATE clientes " +
                      "SET nome = @nome, cpf = @cpf, data_nascimento = @data_nascimento, telefone = @telefone, endereco = @endereco " +
                      $"WHERE matricula = {id}";
                cmd = new MySqlCommand(sql, con.conn);

                cmd.Parameters.AddWithValue("@nome", textNome.Text);
                cmd.Parameters.AddWithValue("@cpf", textCpf.Text);
                cmd.Parameters.AddWithValue("@data_nascimento", textNascimento.Text);
                cmd.Parameters.AddWithValue("@telefone", textTelefone.Text);
                cmd.Parameters.AddWithValue("@endereco", textEndereco.Text);

                if (cpfTemp != textCpf.Text)
                {
                    MessageBox.Show("CPF não pode ser alterado!", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            Listar();
            DesabilitarCampos();
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                textNome.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
                textCpf.Text = dataGrid.CurrentRow.Cells[2].Value.ToString();
                textNascimento.Text = dataGrid.CurrentRow.Cells[3].Value.ToString();
                textTelefone.Text = dataGrid.CurrentRow.Cells[4].Value.ToString();
                textEndereco.Text = dataGrid.CurrentRow.Cells[5].Value.ToString();
                btnEditar.Enabled = true;
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = true;
                cpfTemp = textCpf.Text;
                HabilitarCampos();
            }
        }
    }
}
