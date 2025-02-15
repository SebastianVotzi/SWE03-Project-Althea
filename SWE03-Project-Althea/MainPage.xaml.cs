using SWE03_Bosnia_Logic;
using System.Diagnostics;
using System.Text;
using System.Windows;


namespace SWE03_Project_Althea
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            
        }

        // Event-Handler für den Strat-Button der dich auf die Gamepage bringt
        private async void StartBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new Gamepage());
                Navigation.RemovePage(this);
            }
            catch (Exception exeption)
            {
                Console.WriteLine("No Idea how you managed to fuck up clicking a button this bad like damm");
            }
            


        }

        
    }

}
