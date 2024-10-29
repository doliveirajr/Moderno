using MySql.Data.MySqlClient;
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

namespace Moderno.cadastros
{
    public partial class FrmCadastroCargo : Form
    {
        readonly ConexaoModerno con = new ConexaoModerno();
        string sql;
        MySqlCommand cmd;
        const string MessageBoxTitle = "Cadastro de cargos";
        string id;
        string cargoTemp;

        public FrmCadastroCargo()
        {
            InitializeComponent();
        }

        private void FrmCadastroCargo_Load(object sender, EventArgs e)
        {
            ListarCargos();
        }

        private void ListarCargos()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM cargos ORDER BY id_cargo ASC";
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
            dataGrid.Columns[1].HeaderText = "Cargo";
            dataGrid.Columns[0].Visible = false;
        }

        private void LimparDados()
        {
            textNome.Text = string.Empty;
        }

        private void DesabilitaCampos() { textNome.Enabled = false; }

        private void HabilitaCampo() { textNome.Enabled = true; }

        private bool CargoRepetido(string nome)
        {
            ConexaoModerno con = new ConexaoModerno();
            con.AbrirConexao();
            string sql = "SELECT * FROM cargos WHERE nome = @nome";
            MySqlCommand cmd;
            cmd = new MySqlCommand(sql, con.conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@nome", nome);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmd.ExecuteNonQuery();
            con.FecharConexao();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Cargo " + nome + " já existe!", "Cadastro de funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            textNome.Enabled = true;
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnCancelar.Enabled = true;
            textNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparDados();
            ListarCargos();
            DesabilitaCampos();
            btnNovo.Enabled = true;
            btnCancelar.Enabled = false;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            con.AbrirConexao();

            sql = "INSERT INTO cargos(nome) VALUES(@nome);";
            cmd = new MySqlCommand(sql, con.conn);
            cmd.Parameters.AddWithValue("@nome", textNome.Text);

            if (textNome.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Preencha o nome do cargo", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNome.Focus();
                return;
            }

            if (CargoRepetido(textNome.Text))
            {
                return;
            }

            DialogResult dr = MeuMsgBox.Mostrar("Deseja salvar novo registro ?", MessageBoxTitle);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            cmd.ExecuteNonQuery();
            con.FecharConexao();

            ListarCargos();
            LimparDados();
            DesabilitaCampos();

            btnCancelar.Enabled = false;
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                textNome.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
                btnSalvar.Enabled = false;
                btnNovo.Enabled = false;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
                cargoTemp = textNome.Text;
                HabilitaCampo();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            id = dataGrid.CurrentRow.Cells[0].Value.ToString();

            con.AbrirConexao();
            sql = "UPDATE cargos " +
                  "SET nome = @nome " +
                  $"WHERE id_cargo = {id}";

            if (CargoRepetido(textNome.Text))
            {
                return;
            }

            cmd = new MySqlCommand(sql, con.conn);

            cmd.Parameters.AddWithValue("@nome", textNome.Text);
            if (textNome.Text == cargoTemp)
            {
                MessageBox.Show("Para editar o nome do cargo precisa ser diferente.", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            cmd.ExecuteNonQuery();
            con.FecharConexao();
            ListarCargos();
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = false;
            btnNovo.Enabled = true;
            textNome.Text = string.Empty;

            DesabilitaCampos();
            MessageBox.Show("Registro atualizado com sucesso!", MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            id = dataGrid.CurrentRow.Cells[0].Value.ToString();

            con.AbrirConexao();
            sql = "DELETE FROM cargos " +
                  $"WHERE id_cargo = {id}";
            cmd = new MySqlCommand(sql, con.conn);

            cmd.Parameters.AddWithValue("@nome", textNome.Text);

            DialogResult dr = MeuMsgBox.Mostrar("Deseja excluir novo registro ?", MessageBoxTitle);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            cmd.ExecuteNonQuery();
            con.FecharConexao();
            ListarCargos();
            MessageBox.Show("Registro removido com sucesso!",
                            MessageBoxTitle,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            LimparDados();
            DesabilitaCampos();
            btnCancelar.Enabled = false;
            btnEditar.Enabled = false;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            btnNovo.Enabled = true;
        }
    }
}
