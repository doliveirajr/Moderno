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
    public partial class MeuMsgBox : Form
    {
        public MeuMsgBox()
        {
            InitializeComponent();
        }

        public DialogResult Resultado { get; private set; }

        public static DialogResult Mostrar(string mensagem, string titulo, string btnSim = "Sim", string btnNao = "Não")
        {
            var msgBox = new MeuMsgBox();
            msgBox.Text = titulo;
            msgBox.lblMsgBox.Text = mensagem;
            msgBox.btnSim.Text = btnSim;
            msgBox.btnNao.Text = btnNao;
            msgBox.ShowDialog();
            return msgBox.Resultado;
        }

        private void btnSim_Click(object sender, EventArgs e)
        {
            Resultado = DialogResult.Yes;
            Close();
        }

        private void btnNao_Click(object sender, EventArgs e)
        {
            Resultado = DialogResult.No;
            Close();
        }
    }
}
