namespace SWE03_Project_Althea;

public partial class Gameovermenu : ContentPage
{
    public Gameovermenu()
    {
        InitializeComponent();
    }

    public async void Reset_btnclicked(object sender, EventArgs e)// Startet das Spiel neu
    {
        await Navigation.PushAsync(new Gamepage());
        Navigation.RemovePage(this);
    }
    public void Quit_btnclicked(object sender, EventArgs e)// Schlieﬂt das Programm
    {
       Application.Current.Quit();
    }
}