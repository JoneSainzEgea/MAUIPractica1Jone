namespace Practica1
{
    using TicTacToe;
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

        private async void OnBoxClicked(object sender, EventArgs e)
        {
            ImageButton button = sender as ImageButton;
            if (button.Source != null) return; // Casilla ocupada

            string[] coords = button.CommandParameter.ToString().Split(',');
            int row = int.Parse(coords[0]);
            int column = int.Parse(coords[1]);

            bool isSunsTurn = (game.TurnoActual % 2 == 0);
            button.Source = isSunsTurn ? "sunshine.png" : "planet.png";

            game.jugada(row, column);
            UpdateArrow();

            // Comprobar estado de la partida
            int ganador = game.Ganador();
            if (ganador != 0 || game.EsEmpate())
            {
                string mensaje = ganador == 0 ? "Empate" : (ganador == 1 ? "Sol ha ganado" : "Luna ha ganado");
                if (ganador == 1) SunPointsLabel.Text = (++sunPoints).ToString();
                if (ganador == 2) MoonPointsLabel.Text = (++moonPoints).ToString();

                await DisplayAlert("Game Over", mensaje, "Volver a jugar");
                RestartGame();
            }
        }

        private void UpdateArrow()
        {
            ImgArrow.Source = (game.TurnoActual % 2 == 0) ? "left_arrow.png" : "right_arrow.png";
        }

        private void RestartGame()
        {
            game.Reiniciar();

            sunStartsNext = !sunStartsNext;
            if (!sunStartsNext)
                
                game.CambioTurno();

            foreach (var child in BoardGrid.Children)
            {
                if (child is ImageButton btn) btn.Source = null;
            }
            UpdateArrow();
        }

    }

}
