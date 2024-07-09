namespace MicroondasApp
{
    partial class FormCadastroPrograma
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNome = new System.Windows.Forms.Label();
            this.lblAlimento = new System.Windows.Forms.Label();
            this.lblPotencia = new System.Windows.Forms.Label();
            this.lblCaractere = new System.Windows.Forms.Label();
            this.lblMinutos = new System.Windows.Forms.Label();
            this.lblSegundos = new System.Windows.Forms.Label();
            this.lblInstrucoes = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtAlimento = new System.Windows.Forms.TextBox();
            this.txtPotencia = new System.Windows.Forms.TextBox();
            this.txtCaractere = new System.Windows.Forms.TextBox();
            this.txtMinutos = new System.Windows.Forms.TextBox();
            this.txtSegundos = new System.Windows.Forms.TextBox();
            this.txtInstrucoes = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(12, 9);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";
            // 
            // lblAlimento
            // 
            this.lblAlimento.AutoSize = true;
            this.lblAlimento.Location = new System.Drawing.Point(12, 48);
            this.lblAlimento.Name = "lblAlimento";
            this.lblAlimento.Size = new System.Drawing.Size(51, 13);
            this.lblAlimento.TabIndex = 1;
            this.lblAlimento.Text = "Alimento:";
            // 
            // lblPotencia
            // 
            this.lblPotencia.AutoSize = true;
            this.lblPotencia.Location = new System.Drawing.Point(12, 87);
            this.lblPotencia.Name = "lblPotencia";
            this.lblPotencia.Size = new System.Drawing.Size(52, 13);
            this.lblPotencia.TabIndex = 2;
            this.lblPotencia.Text = "Potência:";
             
            // 
            // lblCaractere
            // 
            this.lblCaractere.AutoSize = true;
            this.lblCaractere.Location = new System.Drawing.Point(12, 126);
            this.lblCaractere.Name = "lblCaractere";
            this.lblCaractere.Size = new System.Drawing.Size(58, 13);
            this.lblCaractere.TabIndex = 3;
            this.lblCaractere.Text = "Caractere:";
            // 
            // lblMinutos
            // 
            this.lblMinutos.AutoSize = true;
            this.lblMinutos.Location = new System.Drawing.Point(12, 165);
            this.lblMinutos.Name = "lblMinutos";
            this.lblMinutos.Size = new System.Drawing.Size(48, 13);
            this.lblMinutos.TabIndex = 4;
            this.lblMinutos.Text = "Minutos:";
            // 
            // lblSegundos
            // 
            this.lblSegundos.AutoSize = true;
            this.lblSegundos.Location = new System.Drawing.Point(12, 204);
            this.lblSegundos.Name = "lblSegundos";
            this.lblSegundos.Size = new System.Drawing.Size(57, 13);
            this.lblSegundos.TabIndex = 5;
            this.lblSegundos.Text = "Segundos:";
            // 
            // lblInstrucoes
            // 
            this.lblInstrucoes.AutoSize = true;
            this.lblInstrucoes.Location = new System.Drawing.Point(12, 243);
            this.lblInstrucoes.Name = "lblInstrucoes";
            this.lblInstrucoes.Size = new System.Drawing.Size(59, 13);
            this.lblInstrucoes.TabIndex = 6;
            this.lblInstrucoes.Text = "Instruções:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 25);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 7;
            // 
            // txtAlimento
            // 
            this.txtAlimento.Location = new System.Drawing.Point(12, 64);
            this.txtAlimento.Name = "txtAlimento";
            this.txtAlimento.Size = new System.Drawing.Size(100, 20);
            this.txtAlimento.TabIndex = 8;
            // 
            // txtPotencia
            // 
            this.txtPotencia.Location = new System.Drawing.Point(12, 103);
            this.txtPotencia.Name = "txtPotencia";
            this.txtPotencia.Size = new System.Drawing.Size(100, 20);
            this.txtPotencia.TabIndex = 9;
            // 
            // txtCaractere
            // 
            this.txtCaractere.Location = new System.Drawing.Point(12, 142);
            this.txtCaractere.Name = "txtCaractere";
            this.txtCaractere.Size = new System.Drawing.Size(100, 20);
            this.txtCaractere.TabIndex = 10;
            // 
            // txtMinutos
            // 
            this.txtMinutos.Location = new System.Drawing.Point(12, 181);
            this.txtMinutos.Name = "txtMinutos";
            this.txtMinutos.Size = new System.Drawing.Size(100, 20);
            this.txtMinutos.TabIndex = 11;
            // 
            // txtSegundos
            // 
            this.txtSegundos.Location = new System.Drawing.Point(12, 220);
            this.txtSegundos.Name = "txtSegundos";
            this.txtSegundos.Size = new System.Drawing.Size(100, 20);
            this.txtSegundos.TabIndex = 12;
            // 
            // txtInstrucoes
            // 
            this.txtInstrucoes.Location = new System.Drawing.Point(12, 259);
            this.txtInstrucoes.Multiline = true;
            this.txtInstrucoes.Name = "txtInstrucoes";
            this.txtInstrucoes.Size = new System.Drawing.Size(260, 60);
            this.txtInstrucoes.TabIndex = 13;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(12, 325);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FormCadastroPrograma
            // 
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtInstrucoes);
            this.Controls.Add(this.txtSegundos);
            this.Controls.Add(this.txtMinutos);
            this.Controls.Add(this.txtCaractere);
            this.Controls.Add(this.txtPotencia);
            this.Controls.Add(this.txtAlimento);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblInstrucoes);
            this.Controls.Add(this.lblSegundos);
            this.Controls.Add(this.lblMinutos);
            this.Controls.Add(this.lblCaractere);
            this.Controls.Add(this.lblPotencia);
            this.Controls.Add(this.lblAlimento);
            this.Controls.Add(this.lblNome);
            this.Name = "FormCadastroPrograma";
            this.Text = "Cadastro de Programa Customizado";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblAlimento;
        private System.Windows.Forms.Label lblPotencia;
        private System.Windows.Forms.Label lblCaractere;
        private System.Windows.Forms.Label lblMinutos;
        private System.Windows.Forms.Label lblSegundos;
        private System.Windows.Forms.Label lblInstrucoes;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtAlimento;
        private System.Windows.Forms.TextBox txtPotencia;
        private System.Windows.Forms.TextBox txtCaractere;
        private System.Windows.Forms.TextBox txtMinutos;
        private System.Windows.Forms.TextBox txtSegundos;
        private System.Windows.Forms.TextBox txtInstrucoes;
        private System.Windows.Forms.Button btnSalvar;
    }
}
