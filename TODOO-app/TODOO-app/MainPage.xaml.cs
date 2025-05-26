using System.Collections.ObjectModel;


namespace TODOO_app;

public partial class MainPage : ContentPage
{


    public ObservableCollection<TaskItem> Items { get; set; }


    public MainPage()
    {
        InitializeComponent();
        Items = new ObservableCollection<TaskItem>();
        BindingContext = this;
    }

    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public string DisplayTime => CreatedTime.ToString("g");
    }

  

    private void OnAddClicked(object sender, EventArgs e)
    {
        string newItem = AddListItem?.Text?.Trim();
        string addtoItem = AddDescription?.Text?.Trim();


        if (!string.IsNullOrEmpty(newItem))
        {

            var task = new TaskItem
            {
                Title = newItem,
                Description = addtoItem,
                CreatedTime = DateTime.Now
            };


            Items.Add(task);
            AddListItem.Text = string.Empty;
            AddDescription.Text = string.Empty;
        }


    }

    private async void DeleteOnClick(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is TaskItem item)
        {
            bool confirm = await DisplayAlert("Ta bort", $"Är du säker på att du vill ta bort '{item.Title}'?", "Ja", "Nej");
            if (confirm)
            {
                Items.Remove(item);
            }
        }
    }
}

