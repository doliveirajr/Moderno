using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moderno
{
    public partial class FrmPdvModerno : Form
    {
        // Campos
        private Button botaoAtual;
        private readonly Random random;
        private int endTemp;
        private Form activeForm;
        Color cor;

        public FrmPdvModerno()
        {
            InitializeComponent();
            random = new Random();
            this.Text  = String.Empty;
            this.ControlBox = false;
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color SelecionaCor()
        {
            int index = random.Next(EsquemaDeCores.ListaDeCores.Count);
            while(endTemp == index)
            {
                index = random.Next(EsquemaDeCores.ListaDeCores.Count);
            }
            endTemp = index;
            string cor = EsquemaDeCores.ListaDeCores[index];
            return ColorTranslator.FromHtml(cor);
        }

        private void AtivaBotao(object btnSender)
        {
            if (btnSender != null)
            {
                if (botaoAtual != (Button)btnSender)
                {
                    DesativaBotao();
                    cor = SelecionaCor();
                    panelHome.BackColor = EsquemaDeCores.MudarBrilho(cor, -0.65);
                    logoPanel.BackColor = EsquemaDeCores.MudarBrilho(cor, 0.05);
                    lblPanelHome.ForeColor = System.Drawing.Color.White;
                    botaoAtual = (Button)btnSender;
                    botaoAtual.BackColor = EsquemaDeCores.MudarBrilho(cor, 0.35);
                    botaoAtual.ForeColor = Color.White;
                    botaoAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void DesativaBotao()
        {
            foreach(Control botaoAnterior in panelMenu.Controls)
            {
                if (botaoAnterior.GetType() == typeof(Button))
                {
                    botaoAnterior.BackColor = Color.Gray;
                    botaoAnterior.ForeColor = Color.Gainsboro;
                    botaoAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (childForm == null)
            {
                activeForm.Close();
            }

            AtivaBotao(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BackColor = cor;
            childForm.BringToFront();
            childForm.Show();
            lblPanelHome.Text = childForm.Text;
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            AtivaBotao(sender);
            OpenChildForm(new cadastros.FrmCadastroCargo(), sender);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AtivaBotao(sender);
            OpenChildForm(new cadastros.FrmCadastroCliente(), sender);
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            AtivaBotao(sender);
            OpenChildForm(new cadastros.FrmCadastroFuncionario(), sender);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            AtivaBotao(sender);
            OpenChildForm(new cadastros.FrmCadastroFornecedor(), sender);
        }

        private void btnIntake_Click(object sender, EventArgs e)
        {
            AtivaBotao(sender);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            AtivaBotao(sender);
        }

        

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmPdvModerno_Load(object sender, EventArgs e)
        {

        }

        private void panelHome_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
