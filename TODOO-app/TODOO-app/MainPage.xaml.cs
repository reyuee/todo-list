using System.Collections.ObjectModel;

namespace TODOO_app;

public partial class MainPage : ContentPage
{
    public ObservableCollection<string> Items { get; set; } = new ObservableCollection<string>();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        string newItem = AddListItem?.Text?.Trim();

        if (!string.IsNullOrEmpty(newItem))
        {
            Items.Add(newItem);
            AddListItem.Text = string.Empty;
        }
    }

    private async void DeleteOnClick(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is string item)
        {
            bool confirm = await DisplayAlert("Ta bort", $"Är du säker på att du vill ta bort '{item}'?", "Ja", "Nej");
            if (confirm)
            {
                Items.Remove(item);
            }
        }
    }
}
