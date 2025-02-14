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


        // Sendet dich zur Gamepage
        private async void StartBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Gamepage());
            Navigation.RemovePage(this);


        }

        
    }

}
