namespace Practica1
{
    using TicTacToe;

    /// <summary>
    /// Lógica de control para la página principal del juego.
    /// Gestiona la interacción entre el usuario y la lógica del Tres en Raya.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        TicTacToe game = new TicTacToe();

        bool sunStartsNext = true;
        int sunPoints = 0;
        int moonPoints = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que se dispara al pulsar cualquier casilla del tablero.
        /// Controla la colocación de fichas, actualización de puntos y detección de fin de partida.
        /// </summary>
        /// <param name="sender">El ImageButton que fue pulsado.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private async void OnBoxClicked(object sender, EventArgs e)
        {
            ImageButton button = sender as ImageButton;
            if (button.Source != null) return; // Casilla ocupada

            // Coordenadas definidas en MainPage.xaml
            string[] coords = button.CommandParameter.ToString().Split(',');
            int row = int.Parse(coords[0]);
            int column = int.Parse(coords[1]);

            // Definir imagen para el botón según el turno
            bool isSunsTurn = (game.TurnoActual % 2 == 0);
            button.Source = isSunsTurn ? "sunshine.png" : "planet.png";

            game.jugada(row, column); // Llamada a TicTacToe.cs

            UpdateArrow(); // Cambio visual de turno con la flecha

            // Comprobar estado de la partida
            int ganador = game.Ganador();
            if (ganador != 0 || game.EsEmpate())
            {
                string mensaje = ganador == 0 ? "Empate" : (ganador == 1 ? "Sol ha ganado" : "Luna ha ganado");
                if (ganador == 1) SunPointsLabel.Text = (++sunPoints).ToString();
                if (ganador == 2) MoonPointsLabel.Text = (++moonPoints).ToString();

                // Mostrar ventana emergente
                await DisplayAlert("Game Over", mensaje, "Volver a jugar");
                RestartGame();
            }
        }


        /// <summary>
        /// Actualiza la imagen de la flecha para señalar de quién es el turno actual
        /// </summary>
        private void UpdateArrow()
        {
            ImgArrow.Source = (game.TurnoActual % 2 == 0) ? "left_arrow.png" : "right_arrow.png";
        }

        /// <summary>
        /// Restablece el estado visual y lógico para comenzar una nueva partida
        /// Alterna el jugador inicial con respecto a la partida anterior
        /// </summary>
        private void RestartGame()
        {
            game.Reiniciar();

            // Alternar el jugador que empieza
            sunStartsNext = !sunStartsNext;
            if (!sunStartsNext)
                game.CambioTurno();

            // Limpia el tablero
            foreach (var child in BoardGrid.Children)
            {
                if (child is ImageButton btn) btn.Source = null;
            }

            UpdateArrow();
        }
    }
}
