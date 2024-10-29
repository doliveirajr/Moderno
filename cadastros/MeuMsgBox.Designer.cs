namespace Moderno.cadastros
{
    partial class MeuMsgBox
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
            this.lblMsgBox = new System.Windows.Forms.Label();
            this.btnNao = new System.Windows.Forms.Button();
            this.btnSim = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMsgBox
            // 
            this.lblMsgBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgBox.Location = new System.Drawing.Point(10, 9);
            this.lblMsgBox.Name = "lblMsgBox";
            this.lblMsgBox.Size = new System.Drawing.Size(312, 141);
            this.lblMsgBox.TabIndex = 5;
            this.lblMsgBox.Text = "label1";
            this.lblMsgBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNao
            // 
            this.btnNao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNao.Location = new System.Drawing.Point(190, 153);
            this.btnNao.Name = "btnNao";
            this.btnNao.Size = new System.Drawing.Size(87, 28);
            this.btnNao.TabIndex = 4;
            this.btnNao.Text = "Não";
            this.btnNao.UseVisualStyleBackColor = true;
            this.btnNao.Click += new System.EventHandler(this.btnNao_Click);
            // 
            // btnSim
            // 
            this.btnSim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSim.Location = new System.Drawing.Point(47, 153);
            this.btnSim.Name = "btnSim";
            this.btnSim.Size = new System.Drawing.Size(87, 28);
            this.btnSim.TabIndex = 3;
            this.btnSim.Text = "Sim";
            this.btnSim.UseVisualStyleBackColor = true;
            this.btnSim.Click += new System.EventHandler(this.btnSim_Click);
            // 
            // MeuMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 191);
            this.Controls.Add(this.lblMsgBox);
            this.Controls.Add(this.btnNao);
            this.Controls.Add(this.btnSim);
            this.Name = "MeuMsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MeuMsgBox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMsgBox;
        private System.Windows.Forms.Button btnNao;
        private System.Windows.Forms.Button btnSim;
    }
}