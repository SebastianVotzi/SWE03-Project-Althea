using SWE03_Bosnia_Logic;
using System.Diagnostics;
using System.Text;
using System.Windows;


namespace SWE03_Project_Althea
{
    public partial class MainPage : ContentPage
    {
        Board b1 = new Board(10, 10, 21);// Das tatsächliche Spielfeld(Schwer)
        Board b2 = new Board(10, 10, 16);// Das tatsächliche Spielfeld(Mittel
        Board b3 = new Board(10, 10, 12);// Das tatsächliche Spielfeld(Einfach)
        public MainPage()
        {
            InitializeComponent();
            
        }

        // Event-Handler für den Strat-Button der dich auf die Gamepage bringt
        private async void StartBtnH_Clicked(object sender, EventArgs e)
        {

            try

            {
                await Navigation.PushAsync(new Gamepage(b1));
                Navigation.RemovePage(this);

            }
            catch (Exception)
            {

                Console.WriteLine("No Idea how you managed to fuck up clicking a button this bad like damm");

            }
            
        }
        // Event-Handler für den Strat-Button der dich auf die Gamepage bringt

        private async void StartBtnM_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new Gamepage(b2));
                Navigation.RemovePage(this);
            }
            catch (Exception)
            {
                Console.WriteLine("No Idea how you managed to fuck up clicking a button this bad like damm");
            }



        }

        // Event-Handler für den Strat-Button der dich auf die Gamepage bringt
        private async void StartBtnE_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new Gamepage(b3));
                Navigation.RemovePage(this);
            }
            catch (Exception)
            {
                Console.WriteLine("No Idea how you managed to fuck up clicking a button this bad like damm");
            }



        }

    }

}
