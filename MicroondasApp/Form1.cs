using MicroondasApp.Classes_e_Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MicroondasApp.Tests")]

namespace MicroondasApp
{
    public partial class Form1 : Form

    {
        private Microondas  _microondas;
        private bool aquecimentoIniciado = false; // Variavel para rastrear se o aquecimento  foi iniciado
        private bool _aquecimentoEmAndamento; // Variável para rastrear o estado do aquecimento
        private int _tempoRestante; // Variável para rastrear o tempo restante
        public Timer _aquecimentoTimer; // Timer para simular o aquecimento 
        private bool _programaPreDefinidoSelecionado = false; 
        private List<ProgramaAquecimento> programasPreDefinidos;
        private List<ProgramaAquecimento> programasExistentes;
        private List<ProgramaAquecimento> programasCustomizados;
        private string jsonFilePath = "programasCustomizados.json";





        public Form1()

        {
            InitializeComponent();
            _microondas = new Microondas();
            aquecimentoIniciado = false; //Indica que o aquecimento iniciado e falso
            _aquecimentoEmAndamento = false; // Inicialmente, o aquecimento não está em andamento
            _tempoRestante = 0;
            programasPreDefinidos = new List<ProgramaAquecimento>();
            programasCustomizados = new List<ProgramaAquecimento>();
            InicializarProgramasPreDefinidos();
            CarregarProgramasCustomizados();
            AtualizarComboBoxProgramas();
            comboBoxProgramas.SelectedIndexChanged += comboBoxProgramas_SelectedIndexChanged;

            comboBoxProgramas.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxProgramas.DrawItem += ComboBoxProgramas_DrawItem;

            _aquecimentoTimer = new Timer();
            _aquecimentoTimer.Interval = 1000; // 1 segundo
            _aquecimentoTimer.Tick += AquecimentoTimer_Tick;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPotencia.Text = "10"; // Define o valor padrão como 10
            InicializarProgramasPreDefinidos();
            comboBoxProgramas.Items.AddRange(programasPreDefinidos.Select(p => p.Nome).ToArray());
            CarregarProgramasCustomizados();
            AtualizarComboBoxProgramas();
            ConfigurarComboBoxProgramas();


        }


                                                    //01.Programas Pre-Definidos



        //Logica para letra em italico

        private void ComboBoxProgramas_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                string texto = comboBoxProgramas.Items[e.Index].ToString();
                Font fonte = e.Font;

                if (texto.EndsWith(" (Personalizado)"))
                {
                    fonte = new Font(e.Font, FontStyle.Italic);
                }

                e.Graphics.DrawString(texto, fonte, Brushes.Black, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        private void ConfigurarComboBoxProgramas()
        {
            comboBoxProgramas.DrawMode = DrawMode.OwnerDrawFixed;
             
        }

     
        //Inicializar os programas pre-definidos
        private void InicializarProgramasPreDefinidos()
        {
            programasPreDefinidos = new List<ProgramaAquecimento>
        {
            new ProgramaAquecimento("Pipoca", "Pipoca (de micro-ondas)", 3 * 60, 7, "*", "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento."),
            new ProgramaAquecimento("Leite", "Leite", 5 * 60, 5, "#", "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras."),
            new ProgramaAquecimento("Carnes de boi", "Carne em pedaço ou fatias", 14 * 60, 4, "@", "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme."),
            new ProgramaAquecimento("Frango", "Frango (qualquer corte)", 8 * 60, 7, "&", "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme."),
            new ProgramaAquecimento("Feijão", "Feijão congelado", 8 * 60, 9, "%", "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas.")
        };
        }

        //Estrutura do combobox dos programas pre definidos
        private void comboBoxProgramas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProgramas.SelectedItem == null)
            {
                return;
            }

            string programaSelecionado = comboBoxProgramas.SelectedItem.ToString();

            // Verificar se é um programa personalizado
            bool isPersonalizado = programaSelecionado.EndsWith(" (Personalizado)");
            string nomePrograma = isPersonalizado ? programaSelecionado.Replace(" (Personalizado)", "") : programaSelecionado;

            ProgramaAquecimento programa = isPersonalizado
                ? programasCustomizados.FirstOrDefault(p => p.Nome.Equals(nomePrograma, StringComparison.OrdinalIgnoreCase))
                : programasPreDefinidos.FirstOrDefault(p => p.Nome == nomePrograma);

            if (programa != null)
            {
                txtMinutos.Text = (programa.Tempo / 60).ToString();
                txtSegundos.Text = (programa.Tempo % 60).ToString();
                txtPotencia.Text = programa.Potencia.ToString();
                lblaquecimento.Text = programa.StringAquecimento;
                lblInstrucoes.Text = programa.Instrucoes;

                txtMinutos.Enabled = !isPersonalizado;
                txtSegundos.Enabled = !isPersonalizado;
                txtPotencia.Enabled = !isPersonalizado;
            }
            else
            {
                MessageBox.Show("Programa não encontrado.");
            }
        }






        //02.Configuraçoes dos botões


        internal void btnConfigurar_Click(object sender, EventArgs e)
        {
            try
            {
                int minutos = int.Parse(txtMinutos.Text);
                int segundos = int.Parse(txtSegundos.Text);
                int potencia = string.IsNullOrEmpty(txtPotencia.Text) ? 10 : int.Parse(txtPotencia.Text);//Inicia com o valor 10 caso nao for informado pelo usuario

                if (minutos < 0 || minutos > 2 || (minutos == 2 && segundos > 0) || segundos < 0 || segundos >= 60)
                {
                    MessageBox.Show("O tempo deve estar entre 1 segundo e 2 minutos.");
                    return;
                }

                if (potencia < 1 || potencia > 10)
                {
                    MessageBox.Show("A potência deve estar entre 1 e 10.");
                    return;
                }

                _microondas.SetTempo(minutos, segundos);
                _microondas.SetPotencia(potencia);

                MessageBox.Show($"Tempo configurado: {_microondas.GetTempo()} segundos\nPotência configurada: {_microondas.GetPotencia()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        //Evento click para focar na caixa e o botao limpar
        private void btnDigito_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string digito = btn.Text;

                if (txtMinutos != null && txtMinutos.Focused)
                {
                    txtMinutos.Text += digito;
                }
                else if (txtSegundos != null && txtSegundos.Focused)
                {
                    txtSegundos.Text += digito;
                }
                else if (txtPotencia != null && txtPotencia.Focused)
                {
                    txtPotencia.Text += digito;
                }
            }
        }

        internal void txtMinutos_Enter(object sender, EventArgs e)
        {
            txtMinutos.SelectAll();
        }

        private void txtSegundos_Enter(object sender, EventArgs e)
        {
            txtSegundos.SelectAll();
        }

        private void txtPotencia_Enter(object sender, EventArgs e)
        {
            txtPotencia.SelectAll();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMinutos.Text = "";
            txtSegundos.Text = "";
            txtPotencia.Text = "";
            txtMinutos.Enabled = true;
            txtSegundos.Enabled = true;
            txtPotencia.Enabled = true;

            lblaquecimento.Text = "";
            lblInstrucoes.Text = "";

            _programaPreDefinidoSelecionado = false;
        }

        //Validação de entrada usando KeyPress
        internal void txtMinutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e tecla Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Validação de entrada usando KeyPress
        private void txtSegundos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e tecla Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Validação de entrada usando KeyPress
        private void txtPotencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e tecla Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //codigo para implementação do botão iniciar
        internal void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar se os campos estão vazios e definir valores padrão para "início rápido"
                int minutos, segundos, potencia;

                if (string.IsNullOrEmpty(txtMinutos.Text) && string.IsNullOrEmpty(txtSegundos.Text) && string.IsNullOrEmpty(txtPotencia.Text))
                {
                    minutos = 0;
                    segundos = 30; // Tempo padrão para "início rápido"
                    potencia = 10; // Potência padrão
                }
                else
                {
                    minutos = int.TryParse(txtMinutos.Text, out int resultMin) ? resultMin : 0;
                    segundos = int.TryParse(txtSegundos.Text, out int resultSeg) ? resultSeg : 0;
                    potencia = int.TryParse(txtPotencia.Text, out int resultPot) ? resultPot : 10;
                }

                int tempoTotal = minutos * 60 + segundos;

                if (tempoTotal < 1 || tempoTotal > 120)
                {
                    MessageBox.Show("O tempo deve estar entre 1 segundo e 2 minutos.");
                    return;
                }

                if (potencia < 1 || potencia > 10)
                {
                    MessageBox.Show("A potência deve estar entre 1 e 10.");
                    return;
                }

                _microondas.IniciarAquecimento(tempoTotal, potencia);
                MessageBox.Show($"Aquecimento iniciado:\nTempo: {_microondas.GetTempo()} segundos ({_microondas.FormatarTempo(_microondas.GetTempo())})\nPotência: {_microondas.GetPotencia()}");

                _tempoRestante = tempoTotal;
                _aquecimentoEmAndamento = true;

                // Iniciar o timer
                if (_aquecimentoTimer == null)
                {
                    MessageBox.Show("Erro: o timer de aquecimento não foi inicializado corretamente.");
                    return;
                }

                _aquecimentoTimer.Start();
                UpdateAquecimentoStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar aquecimento: {ex.Message}");
            }
        }

        //Logica para o timer do aquecimento
        private void AquecimentoTimer_Tick(object sender, EventArgs e)
        {
             

            _tempoRestante--;
            UpdateAquecimentoStatus();
            

            int potencia = _microondas.GetPotencia();
            lblaquecimento.Text += new string('.', potencia) + " ";
            _tempoRestante--;

            if (_tempoRestante <= 0)
            {
                _aquecimentoTimer.Stop();
                _aquecimentoEmAndamento = false; // Aquecimento concluído
                lblaquecimento.Text += "Aquecimento concluído";
                MessageBox.Show("Aquecimento concluído!");
            } 
        }

        private string GerarStringAquecimento(int tempo, int potencia)
        {
            {
                StringBuilder sb = new StringBuilder();

                // Calcula quantos grupos inteiros de pontos serão exibidos
                int grupos = tempo;

                // Preenche cada grupo com o número correto de pontos
                for (int i = 0; i < grupos; i++)
                {
                    if (i > 0)
                        sb.Append(" "); // Adiciona espaço entre os grupos

                    sb.Append(string.Join("", Enumerable.Repeat(".", potencia)));
                }

                // Constrói a string final com a informação de grupos e potência
                string stringAquecimento = $"{grupos}  (segundo(s)):   {potencia}  (potência): {sb.ToString()}";

                return stringAquecimento;
            }

        }

        //logica para atualizar no lblAquecimento
        private void UpdateAquecimentoStatus()
        {
            int potencia = _microondas.GetPotencia();
            int minutosRestantes = _tempoRestante / 60;
            int segundosRestantes = _tempoRestante % 60;
            int tempo = _microondas.GetTempo();  
            string tempoFormatado = FormatarTempo(tempo);
            lblaquecimento.Text = tempoFormatado;

            string stringAquecimento = GerarStringAquecimento(tempo, potencia);

            lblaquecimento.Text = $"Aquecendo... Potência: {potencia}\nTempo Restante: {minutosRestantes:D2}:{segundosRestantes:D2}\n{stringAquecimento}";

        }
        //Formatar o tempo
        public string FormatarTempo(int tempo)
        {
            int minutos = tempo / 60;
            int segundos = tempo % 60;
            return $"{minutos:D2}:{segundos:D2}";

        }

        //logica para cancelar/retornar o aquecimento
        private void btnPausaCancela_Click(object sender, EventArgs e)
        {
            if (!_aquecimentoEmAndamento)
            {
                // Limpar os campos de tempo e potência se o aquecimento não foi iniciado
                txtMinutos.Text = "";
                txtSegundos.Text = "";
                txtPotencia.Text = "";
                lblaquecimento.Text = "";
                MessageBox.Show("Os campos de tempo e potência foram limpos.");
            }
            else
            {
                if (_aquecimentoTimer != null && _aquecimentoTimer.Enabled)
                {
                    // Pausar o aquecimento
                    _aquecimentoTimer.Stop();
                    btnPausaCancela.Text = "Cancelar";
                }
                else
                {
                    if (_aquecimentoTimer != null && !_aquecimentoTimer.Enabled)
                    {
                        // Cancelar o aquecimento
                        _microondas.CancelarAquecimento();
                        _tempoRestante = 0;
                        _aquecimentoEmAndamento = false;
                        txtMinutos.Text = "";
                        txtSegundos.Text = "";
                        txtPotencia.Text = "";
                        lblaquecimento.Text = "";
                        MessageBox.Show("O aquecimento foi cancelado e as informações foram limpas.");
                        btnPausaCancela.Text = "Pausar";
                    }
                }
            }
        }

        //logica para o botão de inicio rapido
        private void btnInicioRapido_Click(object sender, EventArgs e)
        {
            txtMinutos.Text = "";
            txtSegundos.Text = "";
            txtPotencia.Text = "";

            btnIniciar_Click(sender, e);
        }

        //logica para limpar informações dos campos
        private void LimparInformacoes()
        {
            _aquecimentoTimer.Stop();
            _aquecimentoEmAndamento = false;
            _tempoRestante = 0;

            txtMinutos.Text = "";
            txtSegundos.Text = "";
            txtPotencia.Text = "";
            lblaquecimento.Text = "";

            MessageBox.Show("Aquecimento cancelado. Todas as informações foram limpas.");
        }


    
                                         //03.Estrutura de cadastro para as pre-definições 


        //Cadastro de Pre Definição
        private void btnCadastroPrograma_Click(object sender, EventArgs e)
        {
            if (programasPreDefinidos == null)
            {
                programasPreDefinidos = new List<ProgramaAquecimento>();
            }

            if (programasCustomizados == null)
            {
                programasCustomizados = new List<ProgramaAquecimento>();
            }

            List<ProgramaAquecimento> programas = new List<ProgramaAquecimento>(); 
            programas.AddRange(programasCustomizados);

            FormCadastroPrograma formCadastro = new FormCadastroPrograma(programas);
            formCadastro.ShowDialog();
            CarregarProgramasCustomizados();
            AtualizarComboBoxProgramas();
        }


  
        //Carregamento dos Programas
        private void CarregarProgramasCustomizados()
        {
            if (File.Exists(jsonFilePath))
            {
                var json = File.ReadAllText(jsonFilePath);
                programasCustomizados = JsonConvert.DeserializeObject<List<ProgramaAquecimento>>(json);
            }
            else
            {
                programasCustomizados = new List<ProgramaAquecimento>();
            }
        }
 


        //Atualizar o combobox com o programa pre-definido cadastrado
        private void AtualizarComboBoxProgramas()
        {
            comboBoxProgramas.Items.Clear();
            foreach (var programa in programasPreDefinidos)
            {
                comboBoxProgramas.Items.Add(programa.Nome);
            }
             
            foreach (var programa in programasCustomizados)
            {
                comboBoxProgramas.Items.Add(programa.Nome + " (Customizado)");
            }
        }


        //Atualizar os Programas
        private void AtualizarProgramas()
        {
            CarregarProgramasCustomizados();
            AtualizarComboBoxProgramas();
        }

        //Limpar os programas customizados
        private void btnLimparProgramas_Click(object sender, EventArgs e)
        {
            // Limpa a lista de programas customizados
            programasCustomizados.Clear();

            // Salva a lista vazia de programas customizados no arquivo JSON
            SalvarProgramasCustomizados();

            // Atualiza o ComboBox com os programas restantes
            AtualizarComboBoxProgramas();

            MessageBox.Show("Todos os programas personalizados foram apagados.");
        }


        // Método para salvar a lista de programas customizados no arquivo JSON
        private void SalvarProgramasCustomizados()
        {
            string json = JsonConvert.SerializeObject(programasCustomizados, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }

        
    }
}