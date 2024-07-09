using MicroondasApp.Classes_e_Interfaces;
using Newtonsoft.Json;
using System; 
using System.Windows.Forms;
using System.IO;
namespace MicroondasApp


                                                    //Estrutura para funções principais utilizadas no Form1

{
    public class Microondas : IMicroondasConfig
    {
        private int _tempo; // tempo em segundos
        private int _potencia;
        public Timer _aquecimentoTimer;
        public bool AquecimentoIniciado { get; private set; }



        public void SetTempo(int minutos, int segundos)
        {
            _tempo = minutos * 60 + segundos;
        }

        public void SetPotencia(int potencia)
        {
            if (potencia < 1 || potencia > 10)
            {
                throw new ArgumentOutOfRangeException("Potencia deve estar entre 1 e 10.");
            }
            _potencia = potencia;
        }

        public int GetTempo()
        {
            return _tempo;
        }

        public int GetPotencia()
        {
            return _potencia;
        }

        //Metedo para iniciar o aquecimento
        public void IniciarAquecimento(int tempo, int potencia = 10)

        {
            // Validação do tempo
            if (tempo < 1 || tempo > 120)
            {
                throw new ArgumentOutOfRangeException("O tempo deve estar entre 1 segundo e 2 minutos (120 segundos).");
            }

            // Validação da potência
            if (potencia < 1 || potencia > 10)
            {
                throw new ArgumentOutOfRangeException("A potência deve estar entre 1 e 10.");
  
            }

            // Define o tempo e a potência
            _tempo = tempo;
            _potencia = potencia;
             Console.WriteLine($"Iniciando aquecimento: {FormatarTempo(tempo)}, Potência: {potencia}");
        }

        //Metedo para cancelar o aquecimento
        public void CancelarAquecimento()
        {
            _tempo = 0;
            _potencia = 0;
            // Lógica adicional para cancelar o aquecimento
            PararTimer();
            
        }
            
        //Logica para parar o timer
        private void PararTimer()
        {
            // Lógica para parar o timer de aquecimento, se existir
            if (_aquecimentoTimer != null && _aquecimentoTimer.Enabled)
            {
                _aquecimentoTimer.Stop();
            }
        }
 

        //Formatar o tempo
        public string FormatarTempo(int tempo)
        {
            int minutos = tempo / 60;
            int segundos = tempo % 60;
            return $"{minutos:D2}:{segundos:D2}";

        }
    }
}
