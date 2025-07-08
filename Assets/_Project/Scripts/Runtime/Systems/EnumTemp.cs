namespace Temp
{
    public enum GameState
    {
        // controla partida
        Inicializando,
        SorteandoBaralho,
        EmJogo,
        Final
    }

    public enum EmJogoSubState
    {
        // controla um round
        Inicializando,
        DarAsCartas,
        TurnoDoImperador,
        TurnoDoEscravo,
        Resultado
    }

    public enum AIJogandoSubstate
    {
        Aguardando,
        EscolherUmaCarta,
        JogarACarta,
    }

    // Cada classe que controla seu estado dispara um evento ao mudar de estado
}