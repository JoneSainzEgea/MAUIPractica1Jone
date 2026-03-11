namespace TicTacToe;
/// <summary>
/// Funcionalidad del juego
/// </summary>
public class TicTacToe
{
    private int turno;
    public int[,] tablero;

    /// <summary>
    /// Constructor que inicializa el tablero vacío y el turno a 0
    /// </summary>
    public TicTacToe()
    {
        Reiniciar();
    }
    /// <summary>
    /// Realiza jugadas
    /// </summary>
    /// <param name="c">Columna de la jugada</param>
    /// <param name="f">Fila de la jugada</param>
    /// <returns>Número de turno o -1 si la jugada es invalida</returns>
    public int jugada(int f, int c)
    {
        if (tablero[f, c] == 0)
        {
            tablero[f, c] = (turno % 2 == 0) ? 1 : 2;
            turno++;
            return turno;
        }
        return -1;
    }
    /// <summary>
    /// Determina que jugador ha ganado si es que algún jugador ha ganado
    /// </summary>
    /// <returns>Devuelve el jugador ganador 1 o 2 y 0 si no hay ganador</returns>
    public int Ganador()
    {
        if (PartidaFinalizada(1)) return 1;
        if (PartidaFinalizada(2)) return 2;
        return 0;
    }

    public bool EsEmpate() => turno == 9 && Ganador() == 0;

    /// <summary>
    /// Nos devuelve si hay un ganador 
    /// </summary>
    /// <param name="jugador"> Recibe el jugador del cual ha sido el turno</param>
    /// <returns>Devuelve Verdadero si hay un ganador</returns>
    private bool PartidaFinalizada(int jugador)
    {
        for (int i = 0; i < 3; i++)
        {
            if (tablero[i, 0] == jugador && tablero[i, 1] == jugador && tablero[i, 2] == jugador) return true;
            if (tablero[0, i] == jugador && tablero[1, i] == jugador && tablero[2, i] == jugador) return true;
        }
        if (tablero[0, 0] == jugador && tablero[1, 1] == jugador && tablero[2, 2] == jugador) return true;
        if (tablero[0, 2] == jugador && tablero[1, 1] == jugador && tablero[2, 0] == jugador) return true;
        return false;
    }

    /// <summary>
    /// Reinicia el tablero
    /// </summary>
    public void Reiniciar()
    {
        turno = 0;
        tablero = new int[3, 3]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
    }
    /// <summary>
    /// 
    /// </summary>
    public int TurnoActual => turno;

    /// <summary>
    /// Fuerza el turno del segundo jugador
    /// </summary>
    public void CambioTurno()
    {
        turno = 1;
    }
}