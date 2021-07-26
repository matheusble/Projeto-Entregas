namespace LeilãodeEntregas
{
    partial class Leilao
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Leilao));
            this.btnCarregarArquivo = new System.Windows.Forms.Button();
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.lstBTrajeto = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstBEntregas = new System.Windows.Forms.ListBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lstBCaminho = new System.Windows.Forms.ListBox();
            this.lstBTempo = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTrajetos = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCarregarArquivo
            // 
            this.btnCarregarArquivo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCarregarArquivo.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCarregarArquivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarregarArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarregarArquivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCarregarArquivo.Image = global::LeilãodeEntregas.Properties.Resources.envio;
            this.btnCarregarArquivo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCarregarArquivo.Location = new System.Drawing.Point(176, 65);
            this.btnCarregarArquivo.Name = "btnCarregarArquivo";
            this.btnCarregarArquivo.Size = new System.Drawing.Size(113, 29);
            this.btnCarregarArquivo.TabIndex = 0;
            this.btnCarregarArquivo.Text = "UPLOAD MAPA";
            this.btnCarregarArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarregarArquivo.UseVisualStyleBackColor = false;
            this.btnCarregarArquivo.Click += new System.EventHandler(this.btnCarregarArquivo_Click);
            // 
            // txtCaminho
            // 
            this.txtCaminho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCaminho.Enabled = false;
            this.txtCaminho.Location = new System.Drawing.Point(14, 28);
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.Size = new System.Drawing.Size(423, 29);
            this.txtCaminho.TabIndex = 1;
            // 
            // lstBTrajeto
            // 
            this.lstBTrajeto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstBTrajeto.FormattingEnabled = true;
            this.lstBTrajeto.ItemHeight = 23;
            this.lstBTrajeto.Location = new System.Drawing.Point(12, 39);
            this.lstBTrajeto.Name = "lstBTrajeto";
            this.lstBTrajeto.Size = new System.Drawing.Size(271, 303);
            this.lstBTrajeto.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Red;
            this.groupBox2.Controls.Add(this.lstBTrajeto);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(956, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 360);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mapa";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Red;
            this.groupBox1.Controls.Add(this.txtCaminho);
            this.groupBox1.Controls.Add(this.btnCarregarArquivo);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(805, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carregar Mapa";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Red;
            this.groupBox3.Controls.Add(this.lstBEntregas);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(956, 484);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(296, 189);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Entregas";
            // 
            // lstBEntregas
            // 
            this.lstBEntregas.FormattingEnabled = true;
            this.lstBEntregas.ItemHeight = 21;
            this.lstBEntregas.Location = new System.Drawing.Point(6, 23);
            this.lstBEntregas.Name = "lstBEntregas";
            this.lstBEntregas.Size = new System.Drawing.Size(284, 151);
            this.lstBEntregas.TabIndex = 0;
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.Transparent;
            this.btnCalcular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcular.Enabled = false;
            this.btnCalcular.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.ForeColor = System.Drawing.Color.Black;
            this.btnCalcular.Image = global::LeilãodeEntregas.Properties.Resources.path_32;
            this.btnCalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalcular.Location = new System.Drawing.Point(6, 28);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(195, 69);
            this.btnCalcular.TabIndex = 7;
            this.btnCalcular.Text = "Calcular Trajetoria priorizando lucro";
            this.btnCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lstBCaminho
            // 
            this.lstBCaminho.FormattingEnabled = true;
            this.lstBCaminho.ItemHeight = 21;
            this.lstBCaminho.Location = new System.Drawing.Point(287, 25);
            this.lstBCaminho.Name = "lstBCaminho";
            this.lstBCaminho.Size = new System.Drawing.Size(517, 67);
            this.lstBCaminho.TabIndex = 8;
            this.lstBCaminho.Visible = false;
            // 
            // lstBTempo
            // 
            this.lstBTempo.FormattingEnabled = true;
            this.lstBTempo.ItemHeight = 21;
            this.lstBTempo.Location = new System.Drawing.Point(992, 25);
            this.lstBTempo.Name = "lstBTempo";
            this.lstBTempo.Size = new System.Drawing.Size(210, 67);
            this.lstBTempo.TabIndex = 9;
            this.lstBTempo.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Red;
            this.groupBox4.Controls.Add(this.lblTempo);
            this.groupBox4.Controls.Add(this.lblTrajetos);
            this.groupBox4.Controls.Add(this.lstBCaminho);
            this.groupBox4.Controls.Add(this.lstBTempo);
            this.groupBox4.Controls.Add(this.btnCalcular);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(1, 692);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1251, 103);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tragetórias";
            // 
            // lblTrajetos
            // 
            this.lblTrajetos.AutoSize = true;
            this.lblTrajetos.Location = new System.Drawing.Point(207, 43);
            this.lblTrajetos.Name = "lblTrajetos";
            this.lblTrajetos.Size = new System.Drawing.Size(74, 21);
            this.lblTrajetos.TabIndex = 10;
            this.lblTrajetos.Text = "Trajetos:";
            this.lblTrajetos.Visible = false;
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(838, 43);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(148, 21);
            this.lblTempo.TabIndex = 11;
            this.lblTempo.Text = "Tempo de entrega:";
            this.lblTempo.Visible = false;
            // 
            // Leilao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::LeilãodeEntregas.Properties.Resources.Delivery_Express;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1252, 798);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Leilao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leilão de Entregas";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCarregarArquivo;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.ListBox lstBTrajeto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstBEntregas;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.ListBox lstBCaminho;
        private System.Windows.Forms.ListBox lstBTempo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label lblTrajetos;
    }
}

