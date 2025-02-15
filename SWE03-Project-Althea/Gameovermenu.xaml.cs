namespace SWE03_Project_Althea;

public partial class Gameovermenu : ContentPage
{

    public Gameovermenu()
    {

        InitializeComponent();

    }

    //Reset Event-Handler, welcher das Spiel zurücksetzt in dem er eine neue Gamepage erstellt.
    public async void Reset_btnclicked(object sender, EventArgs e)
	{

        await Navigation.PushAsync(new Gamepage());
        Navigation.RemovePage(this);

    }

    //Quit Event-Handelr, wlecher das Programm schließt 
    public void Quit_btnclicked(object sender, EventArgs e)
    {

       Application.Current.Quit();

    }
}