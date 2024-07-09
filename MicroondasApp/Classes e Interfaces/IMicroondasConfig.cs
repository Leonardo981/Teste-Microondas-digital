namespace MicroondasApp
{
    public interface IMicroondasConfig
    {
        void SetTempo(int minutos, int segundos);
        void SetPotencia(int potencia);
        int GetTempo();  // Retorna o tempo total em segundos
        int GetPotencia();
    }
}
