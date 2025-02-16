using SWE03_Bosnia_Logic;
using System.Diagnostics;

namespace SWE03_Project_Althea;

public partial class Gamepage : ContentPage
{
    private Board b1;
    

    Grid buttonGrid = new Grid
    {

        HorizontalOptions = LayoutOptions.Fill,
        VerticalOptions = LayoutOptions.Fill,
        RowSpacing = 0, // Entfernt den Abstand zwischen den Zeilen
        ColumnSpacing = 0 // Entfernt den Abstand zwischen den Spalten

    };

    public Gamepage(Board b1)
    {
        this.b1 = b1;

        InitializeComponent();

        // Fügt 10 Zeilen und 10 Spalten zum Grid hinzu
        for (int i = 0; i < 10; i++)
        {
            buttonGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }

        // Fügt 100 Buttons zum Grid hinzu
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 10; col++)
            {
                var button = new Button
                {
                    Text = "", 
                    BackgroundColor = Colors.Gray,
                    CornerRadius = 5 ,
                    Padding = 0, 
                    Margin = 2 
                };

                // Fügt die Buttons zum Grid hinzu
                buttonGrid.Children.Add(button);
                Grid.SetRow(button, row);
                Grid.SetColumn(button, col);

                // Fügt einen Event-Handler für das Click-Event hinzu
                button.Clicked += OnGridButtonClicked;
            }
        }
        this.Content = buttonGrid;
    }

    // Event-Handler für das Click-Event
    private async void OnGridButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        int row = Grid.GetRow(button);
        int col = Grid.GetColumn(button);
        

        b1.Clicked(row, col);
        UpdateUI();
        if (b1.Gameover)//Gameovermenu wird aufgerufen
        {
            
            await Navigation.PushAsync(new Gameovermenu());
            Navigation.RemovePage(this);
        }

    }

    private Button GetButtonAt(int x, int y)
    {
        // Durchlauft alle Kinder des Grids und findet die Buttons an der Position (x, y)
        foreach (var child in buttonGrid.Children)
        {
            if (buttonGrid.GetRow(child) == x && buttonGrid.GetColumn(child) == y)
            {
                return (Button)child;
            }
        }
        return null; // Falls keine Schaltfläche gefunden wurde
    }
    // Aktualisiert die Benutzeroberfläche
    private void UpdateUI()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                var button = GetButtonAt(x, y); // Holt die Schaltfläche an der Position (x, y)
                var tile = b1.GameBoard[x, y];

                if (tile.IsRevealed)
                {
                    if (tile.IsMine)
                    {
                        button.Text = "M"; // Mine anzeigen

                    }
                    else
                    {
                        button.Text = tile.AdjacentMines > 0 ? tile.AdjacentMines.ToString() : ""; // Anzahl der Minen anzeigen
                    }
                    button.IsEnabled = false; // Schaltfläche deaktivieren
                }
                else
                {
                    button.Text = ""; // Verdecktes Feld
                    button.IsEnabled = true;
                }
            }
        }
    }


}