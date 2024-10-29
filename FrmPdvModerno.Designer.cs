namespace Moderno
{
    partial class FrmPdvModerno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelHome = new System.Windows.Forms.Panel();
            this.lblPanelHome = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnIntake = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnProduto = new System.Windows.Forms.Button();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelMenu.Controls.Add(this.btnReport);
            this.panelMenu.Controls.Add(this.btnIntake);
            this.panelMenu.Controls.Add(this.btnSales);
            this.panelMenu.Controls.Add(this.btnClients);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.btnProduto);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 548);
            this.panelMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.logoPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 100);
            this.panel1.TabIndex = 1;
            // 
            // panelHome
            // 
            this.panelHome.BackColor = System.Drawing.Color.DarkCyan;
            this.panelHome.Controls.Add(this.btnFechar);
            this.panelHome.Controls.Add(this.btnMaximizar);
            this.panelHome.Controls.Add(this.btnMinimizar);
            this.panelHome.Controls.Add(this.lblPanelHome);
            this.panelHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHome.Font = new System.Drawing.Font("Modern No. 20", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelHome.Location = new System.Drawing.Point(220, 0);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(826, 100);
            this.panelHome.TabIndex = 1;
            this.panelHome.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHome_MouseDown);
            // 
            // lblPanelHome
            // 
            this.lblPanelHome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPanelHome.AutoSize = true;
            this.lblPanelHome.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanelHome.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPanelHome.Location = new System.Drawing.Point(367, 34);
            this.lblPanelHome.Name = "lblPanelHome";
            this.lblPanelHome.Size = new System.Drawing.Size(75, 27);
            this.lblPanelHome.TabIndex = 0;
            this.lblPanelHome.Text = "HOME";
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 100);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(826, 448);
            this.panelDesktop.TabIndex = 2;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Image = global::Moderno.Properties.Resources.Close_12;
            this.btnFechar.Location = new System.Drawing.Point(778, 34);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(45, 43);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.FlatAppearance.BorderSize = 0;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizar.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximizar.Image = global::Moderno.Properties.Resources.Enlarge;
            this.btnMaximizar.Location = new System.Drawing.Point(732, 34);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(45, 38);
            this.btnMaximizar.TabIndex = 2;
            this.btnMaximizar.UseVisualStyleBackColor = true;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizar.Image = global::Moderno.Properties.Resources.Horizontal_Line;
            this.btnMinimizar.Location = new System.Drawing.Point(681, 29);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(45, 43);
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.DimGray;
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReport.Image = global::Moderno.Properties.Resources.Business_Report;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(0, 405);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnReport.Size = new System.Drawing.Size(220, 61);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "Relatórios";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnIntake
            // 
            this.btnIntake.BackColor = System.Drawing.Color.DimGray;
            this.btnIntake.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnIntake.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIntake.FlatAppearance.BorderSize = 0;
            this.btnIntake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIntake.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIntake.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnIntake.Image = global::Moderno.Properties.Resources.Cash;
            this.btnIntake.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIntake.Location = new System.Drawing.Point(0, 344);
            this.btnIntake.Name = "btnIntake";
            this.btnIntake.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnIntake.Size = new System.Drawing.Size(220, 61);
            this.btnIntake.TabIndex = 6;
            this.btnIntake.Text = "Caixa";
            this.btnIntake.UseVisualStyleBackColor = false;
            this.btnIntake.Click += new System.EventHandler(this.btnIntake_Click);
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.Color.DimGray;
            this.btnSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSales.Image = global::Moderno.Properties.Resources.Worldwide_Delivery;
            this.btnSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSales.Location = new System.Drawing.Point(0, 283);
            this.btnSales.Name = "btnSales";
            this.btnSales.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnSales.Size = new System.Drawing.Size(220, 61);
            this.btnSales.TabIndex = 5;
            this.btnSales.Text = "Vendas";
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.DimGray;
            this.btnClients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClients.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClients.Image = global::Moderno.Properties.Resources.People_1;
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.Location = new System.Drawing.Point(0, 222);
            this.btnClients.Name = "btnClients";
            this.btnClients.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnClients.Size = new System.Drawing.Size(220, 61);
            this.btnClients.TabIndex = 4;
            this.btnClients.Text = "Clientes";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.DimGray;
            this.btnUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUsuarios.Image = global::Moderno.Properties.Resources.Permanent_Job_1;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 161);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(220, 61);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "Usuários";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnProduto
            // 
            this.btnProduto.BackColor = System.Drawing.Color.DimGray;
            this.btnProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProduto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduto.FlatAppearance.BorderSize = 0;
            this.btnProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduto.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProduto.Image = global::Moderno.Properties.Resources.Shopping_Cart_1;
            this.btnProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduto.Location = new System.Drawing.Point(0, 100);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnProduto.Size = new System.Drawing.Size(220, 61);
            this.btnProduto.TabIndex = 2;
            this.btnProduto.Text = "Produtos";
            this.btnProduto.UseVisualStyleBackColor = false;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.BackgroundImage = global::Moderno.Properties.Resources.C_Sharp_Logo_2;
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(220, 100);
            this.logoPanel.TabIndex = 0;
            // 
            // FrmPdvModerno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 548);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.panelMenu);
            this.Name = "FrmPdvModerno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmPdvModerno_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelHome.ResumeLayout(false);
            this.panelHome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnIntake;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Label lblPanelHome;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnMinimizar;
    }
}

