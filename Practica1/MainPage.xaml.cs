namespace Practica1
{
    public partial class MainPage : ContentPage
    {
        bool isSunsTurn = true;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnBoxClicked(object sender, EventArgs e)
        {
            ImageButton button = sender as ImageButton;

            if(button.Source == null) // Verificar que el botón no tenga imagen
            {
                if (isSunsTurn)
                    button.Source = "sunshine.png";
                else
                    button.Source = "planet.png";
            }

            isSunsTurn = !isSunsTurn;
        }

    }

}
