using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

                                                    //Classe com getter e setter para cadastro de pre-definição
                                                                       

namespace MicroondasApp.Classes_e_Interfaces
{
    public class ProgramaAquecimento
    {
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public int Tempo { get; set; }  
        public int Potencia { get; set; }
        public string StringAquecimento { get; set; }
        public string Instrucoes { get; set; }

        public ProgramaAquecimento(string nome, string alimento, int tempo, int potencia, string stringAquecimento, string instrucoes)
        {
            Nome = nome;
            Alimento = alimento;
            Tempo = tempo;
            Potencia = potencia;
            StringAquecimento = stringAquecimento;
            Instrucoes = instrucoes;
        }
    }
}
