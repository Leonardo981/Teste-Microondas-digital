namespace MicroondasApp
{

    partial class Form1
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
            this.txtMinutos = new System.Windows.Forms.TextBox();
            this.txtSegundos = new System.Windows.Forms.TextBox();
            this.txtPotencia = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblaquecimento = new System.Windows.Forms.Label();
            this.btnPausaCancela = new System.Windows.Forms.Button();
            this.comboBoxProgramas = new System.Windows.Forms.ComboBox();
            this.lblInstrucoes = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnlimparp = new System.Windows.Forms.Button();
            this.btnrapido = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMinutos
            // 
            this.txtMinutos.Location = new System.Drawing.Point(487, 78);
            this.txtMinutos.Name = "txtMinutos";
            this.txtMinutos.Size = new System.Drawing.Size(98, 22);
            this.txtMinutos.TabIndex = 0;
            this.txtMinutos.Text = "Minutos";
            this.txtMinutos.Click += new System.EventHandler(this.btnDigito_Click);
            this.txtMinutos.Enter += new System.EventHandler(this.txtMinutos_Enter);
            this.txtMinutos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinutos_KeyPress);
            // 
            // txtSegundos
            // 
            this.txtSegundos.Location = new System.Drawing.Point(591, 78);
            this.txtSegundos.Name = "txtSegundos";
            this.txtSegundos.Size = new System.Drawing.Size(98, 22);
            this.txtSegundos.TabIndex = 1;
            this.txtSegundos.Text = "Segundos";
            this.txtSegundos.Click += new System.EventHandler(this.btnDigito_Click);
            this.txtSegundos.Enter += new System.EventHandler(this.txtSegundos_Enter);
            this.txtSegundos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSegundos_KeyPress);
            // 
            // txtPotencia
            // 
            this.txtPotencia.Location = new System.Drawing.Point(695, 78);
            this.txtPotencia.Name = "txtPotencia";
            this.txtPotencia.Size = new System.Drawing.Size(100, 22);
            this.txtPotencia.TabIndex = 2;
            this.txtPotencia.Text = "Potencia";
            this.txtPotencia.Click += new System.EventHandler(this.btnDigito_Click);
            this.txtPotencia.Enter += new System.EventHandler(this.txtPotencia_Enter);
            this.txtPotencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPotencia_KeyPress);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(614, 106);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(407, 373);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(202, 23);
            this.btnIniciar.TabIndex = 14;
            this.btnIniciar.Text = "Iniciar /+30seg";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblaquecimento
            // 
            this.lblaquecimento.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblaquecimento.Location = new System.Drawing.Point(12, 106);
            this.lblaquecimento.Name = "lblaquecimento";
            this.lblaquecimento.Size = new System.Drawing.Size(452, 155);
            this.lblaquecimento.TabIndex = 5;
            // 
            // btnPausaCancela
            // 
            this.btnPausaCancela.Location = new System.Drawing.Point(615, 373);
            this.btnPausaCancela.Name = "btnPausaCancela";
            this.btnPausaCancela.Size = new System.Drawing.Size(173, 23);
            this.btnPausaCancela.TabIndex = 15;
            this.btnPausaCancela.Text = "Pausar/Cancelar";
            this.btnPausaCancela.UseVisualStyleBackColor = true;
            this.btnPausaCancela.Click += new System.EventHandler(this.btnPausaCancela_Click);
            // 
            // comboBoxProgramas
            // 
            this.comboBoxProgramas.FormattingEnabled = true;
            this.comboBoxProgramas.Location = new System.Drawing.Point(564, 190);
            this.comboBoxProgramas.Name = "comboBoxProgramas";
            this.comboBoxProgramas.Size = new System.Drawing.Size(165, 24);
            this.comboBoxProgramas.TabIndex = 16;
            // 
            // lblInstrucoes
            // 
            this.lblInstrucoes.AutoSize = true;
            this.lblInstrucoes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblInstrucoes.Location = new System.Drawing.Point(12, 295);
            this.lblInstrucoes.Name = "lblInstrucoes";
            this.lblInstrucoes.Size = new System.Drawing.Size(189, 16);
            this.lblInstrucoes.TabIndex = 4;
            this.lblInstrucoes.Text = "Instruções serão exibidas aqui";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(535, 220);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(231, 23);
            this.btnadd.TabIndex = 0;
            this.btnadd.Text = "Cadastrar Programas Pre-Definidos";
            this.btnadd.Click += new System.EventHandler(this.btnCadastroPrograma_Click);
            // 
            // btnlimparp
            // 
            this.btnlimparp.Location = new System.Drawing.Point(564, 249);
            this.btnlimparp.Name = "btnlimparp";
            this.btnlimparp.Size = new System.Drawing.Size(165, 23);
            this.btnlimparp.TabIndex = 17;
            this.btnlimparp.Text = "Limpar Personalizados";
            this.btnlimparp.UseVisualStyleBackColor = true;
            this.btnlimparp.Click += new System.EventHandler(this.btnLimparProgramas_Click);
            // 
            // btnrapido
            // 
            this.btnrapido.Location = new System.Drawing.Point(567, 402);
            this.btnrapido.Name = "btnrapido";
            this.btnrapido.Size = new System.Drawing.Size(125, 23);
            this.btnrapido.TabIndex = 8;
            this.btnrapido.Text = "Início Rápido";
            this.btnrapido.UseVisualStyleBackColor = true;
            this.btnrapido.Click += new System.EventHandler(this.btnInicioRapido_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(487, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(99, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Input Minutos";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(592, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 18;
            this.textBox2.Text = "Input Segundos";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(695, 50);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 19;
            this.textBox3.Text = "Input Potencia";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnrapido);
            this.Controls.Add(this.btnlimparp);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lblInstrucoes);
            this.Controls.Add(this.comboBoxProgramas);
            this.Controls.Add(this.btnPausaCancela);
            this.Controls.Add(this.lblaquecimento);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtPotencia);
            this.Controls.Add(this.txtSegundos);
            this.Controls.Add(this.txtMinutos);
            this.Name = "Form1";
            this.Text = "Microondas Digital";
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        internal System.Windows.Forms.TextBox txtMinutos;
        internal System.Windows.Forms.TextBox txtSegundos;
        internal System.Windows.Forms.TextBox txtPotencia;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblaquecimento;
        private System.Windows.Forms.Button btnPausaCancela;
        private System.Windows.Forms.ComboBox comboBoxProgramas;
        private System.Windows.Forms.Label lblInstrucoes;   
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnlimparp;
        private System.Windows.Forms.Button btnrapido;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

