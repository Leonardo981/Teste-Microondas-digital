using MicroondasApp.Classes_e_Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


                                             //Estrutura para o cadastro dos programas pre-definidos
namespace MicroondasApp
{
    public partial class FormCadastroPrograma : Form
    {
        private List<ProgramaAquecimento> programasExistentes; 
        List<ProgramaAquecimento> programasSelecionados = new List<ProgramaAquecimento>(); 
        private string jsonFilePath = "programasCustomizados.json";

        public FormCadastroPrograma(List<ProgramaAquecimento> programasExistentes)
        {
            InitializeComponent();
            this.programasExistentes = programasExistentes;
        }
 
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string alimento = txtAlimento.Text;
            string potenciaStr = txtPotencia.Text;
            string caractere = txtCaractere.Text;
            string minutosStr = txtMinutos.Text;
            string segundosStr = txtSegundos.Text;
            string instrucoes = txtInstrucoes.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(alimento) ||
                string.IsNullOrWhiteSpace(potenciaStr) || string.IsNullOrWhiteSpace(caractere) ||
                string.IsNullOrWhiteSpace(minutosStr) || string.IsNullOrWhiteSpace(segundosStr))
            {
                MessageBox.Show("Os campos Nome, Alimento, Potência, Caractere e Tempo são obrigatórios.");
                return;
            }

            // Validação da potência
            if (!int.TryParse(potenciaStr, out int potencia) || potencia < 1 || potencia > 10)
            {
                MessageBox.Show("A potência deve ser um número entre 1 e 10.");
                return;
            }

            // Validação do caractere de aquecimento
            if (caractere == ".")
            {
                MessageBox.Show("O caractere de aquecimento não pode ser \".\".");
                return;
            }

            // Verificação se o caractere de aquecimento já existe
            if (programasExistentes.Any(p => p.StringAquecimento == caractere))
            {
                MessageBox.Show("O caractere de aquecimento não pode se repetir.");
                return;
            }

            // Validação dos campos de tempo (minutos e segundos)
            if (!int.TryParse(minutosStr, out int minutos) || minutos < 0 || minutos > 59)
            {
                MessageBox.Show("Os minutos devem ser um número entre 0 e 59.");
                return;
            }

            if (!int.TryParse(segundosStr, out int segundos) || segundos < 0 || segundos > 59)
            {
                MessageBox.Show("Os segundos devem ser um número entre 0 e 59.");
                return;
            }

            int tempoTotal = minutos * 60 + segundos;

            // Criação do novo programa de aquecimento
            var novoPrograma = new ProgramaAquecimento(nome, alimento, tempoTotal, potencia, caractere, instrucoes);
            programasExistentes.Add(novoPrograma);
            SalvarProgramasCustomizados();

            MessageBox.Show("Programa customizado salvo com sucesso!");
            this.Close();
        }


        private void txtPotencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada não é um número nem a tecla Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela a entrada da tecla se não for um número nem Backspace
            }
        }
        private void txtMinutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada não é um número nem a tecla Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela a entrada da tecla se não for um número nem Backspace
            }
        }
        private void txtSegundos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada não é um número nem a tecla Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela a entrada da tecla se não for um número nem Backspace
            }
        }

        private void SalvarProgramasCustomizados()
        {
            var programasCustomizados = programasExistentes.Where(p => !programasSelecionados .Any(pp => pp.Nome == p.Nome)).ToList();
            File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(programasCustomizados));
        }
    }


}