namespace MicroondasApp
{
    public class Microondas : IMicroondasConfig
    {
        private int _tempo; // tempo em segundos
        private int _potencia;

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
    }
}
