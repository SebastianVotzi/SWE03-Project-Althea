

namespace SWE03_Project_Althea;

public partial class Winmenu : ContentPage
{

    // oder: XAML:
    // xmlns:local="clr-namespace:<Project Name>"
    // <ContentPage.BindingContext>
    // <local:MainWindowViewModel/>
    // </ContentPage.BindingContext>

    public Winmenu()
    {

        InitializeComponent();
        
    }

    //Reset Event-Handler, welcher das Spiel zurücksetzt in dem er eine neue Gamepage erstellt.
    public async void Reset_btnclicked(object sender, EventArgs e)
	{

        await Navigation.PushAsync(new MainPage());
        Navigation.RemovePage(this);

    }

    //Quit Event-Handelr, wlecher das Programm schließt 
    public void Quit_btnclicked(object sender, EventArgs e)
    {

       Application.Current.Quit();

    }
    
}