using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moderno
{
    internal class Validacao
    {
        public bool IsCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string cpfTemp;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf[0] == cpf[1] && cpf[1] == cpf[2] && cpf[2] == cpf[3] && cpf[3] == cpf[4] && cpf[4] == cpf[5] && cpf[5] == cpf[6] && cpf[6] == cpf[7] && cpf[7] == cpf[8] && cpf[8] == cpf[9] && cpf[9] == cpf[10] || cpf.Length != 11)
                return false;

            cpfTemp = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpfTemp[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();

            cpfTemp = cpfTemp + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpfTemp[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito += resto.ToString();

            if (cpf.EndsWith(digito))
            {
                return cpf.EndsWith(digito);
            }
            else
            {
                MessageBox.Show("CPF INVALIDO!", "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


        }

        public bool IsCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (cnpj.EndsWith(digito))
            {
                return cnpj.EndsWith(digito);
            }
            else
            {
                MessageBox.Show("CNPJ INVALIDO!", "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public bool IsValid(string cpfCnpj)
        {
            return IsCPF(cpfCnpj) || IsCNPJ(cpfCnpj);
        }

        public bool CpfExiste(string cpf, string nomeDb)
        {
            ConexaoModerno con = new ConexaoModerno();
            con.AbrirConexao();
            string sql = $"SELECT * FROM {nomeDb} WHERE cpf = @cpf";
            MySqlCommand cmd;
            cmd = new MySqlCommand(sql, con.conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@cpf", cpf);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmd.ExecuteNonQuery();
            con.FecharConexao();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("CPF já registrado", "Cadastro de funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        public bool CnpjExiste(string cnpj, string nomeDb)
        {
            ConexaoModerno con = new ConexaoModerno();
            con.AbrirConexao();
            string sql = $"SELECT * FROM {nomeDb} WHERE cnpj = @cnpj";
            MySqlCommand cmd;
            cmd = new MySqlCommand(sql, con.conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@cnpj", cnpj);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmd.ExecuteNonQuery();
            con.FecharConexao();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("CNPJ já registrado", "Cadastro de fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        public bool CargoExiste(string cargo)
        {
            ConexaoModerno con = new ConexaoModerno();
            con.AbrirConexao();
            string sql = $"SELECT * FROM cargos WHERE nome = {cargo}";
            MySqlCommand cmd;
            cmd = new MySqlCommand(sql, con.conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@nome", cargo);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmd.ExecuteNonQuery();
            con.FecharConexao();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Cargo já registrado", "Cadastro de funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        public bool ValidarEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch(FormatException)
            {
                MessageBox.Show("Email inválido!", "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}

