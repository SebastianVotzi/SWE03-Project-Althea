using SWE03_Bosnia_Logic;

namespace SWE03_Project_Althea;

public partial class Gamepage : ContentPage
{
    Board b1 = new Board(10, 10, 21, new int[10,10,21]);
    bool[,] aufgedeckt = new bool[10, 10];
    
    
    public Gamepage()
    {
        InitializeComponent();




        // Erstellt einen Gird beim öffnen der Seite
        Grid buttonGrid = new Grid
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            RowSpacing = 0, // Entfernt spacing zwischen den Reihen
            ColumnSpacing = 0 // Entfernt spacing zwischen den Spalten
        };

        // Fügt 10 Reihen und 10 Spalten hinzu
        for (int i = 0; i < 10; i++)
        {
            buttonGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }

        // Fügt Buttons zu jedem Feld hinzu
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 10; col++)
            {
                var button = new Button
                {
                    Text = $"", // 
                    BackgroundColor = Colors.Gray,
                    CornerRadius = 5 ,
                    Padding = 0, 
                    Margin = 2 
                };

                // Fügt den Button zum Grid hinzu
                buttonGrid.Children.Add(button);
                Grid.SetRow(button, row);
                Grid.SetColumn(button, col);

                // Fügt Eventhandler zum Button hinzu
                button.Clicked += OnGridButtonClicked;
            }
        }
        this.Content = buttonGrid;
    }

    // Eventhandler für die Buttons im Grid
    private async void OnGridButtonClicked(object sender, EventArgs e)
    {
        Microsoft.Maui.Controls.Button button = (Button)sender;
        //Position des Buttons im Grid in x und y Achse
        int row = Grid.GetRow(button);
        int col = Grid.GetColumn(button);
        
        aufgedeckt[row, col] = false;

        if (b1.Clicked(row, col) == true) 
        {
            button.Text = "0";
            Aufdecken(row, col,b1.GameBoard,aufgedeckt, button);
        }
        // Game over Funktion bringt die auf die Gameoverseite
        else
        {
            button.Text = "1";
            await Navigation.PushAsync(new Gameovermenu());
            Navigation.RemovePage(this);
        }
        
    }

    public void Aufdecken(int x, int y, int[,,] spielfeld, bool[,] aufgedeckt, Microsoft.Maui.Controls.Button button)
    {
        if (x < 0 || x >= aufgedeckt.GetLength(0) || y < 0 || y >= aufgedeckt.GetLength(1))
            return;

        // Überprüfen, ob das Feld bereits aufgedeckt ist
        if (aufgedeckt[x, y])
            return;

        // Feld aufdecken
        aufgedeckt[x, y] = true;
        button.Text = "0";


        // Wenn das Feld eine Mine ist, stoppen wir die Rekursion
        if (spielfeld[x, y, 0] == -1) // 1 repräsentiert eine Mine
            return;

        // Wenn das Feld eine 0 ist, decken wir alle benachbarten Felder auf
        if (spielfeld[x, y, 0] == 0)
        {
            // Alle 8 benachbarten Felder überprüfen
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0)
                        continue; // Das aktuelle Feld überspringen
                    Aufdecken(x + dx, y + dy, spielfeld, aufgedeckt, button);
                }
            }
        }
    }
}