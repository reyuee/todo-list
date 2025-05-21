using System.Collections.ObjectModel;

namespace TODOO_app
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<string>();
            this.BindingContext = this;
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddListItem.Text))
            {
                Items.Add(AddListItem.Text);
                AddListItem.Text = string.Empty;
            }
        }

        private async void DeleteOnClick(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is string item)
            {
                bool answer = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete '{item}'?", "Yes", "No");
                if (answer)
                {
                    Items.Remove(item);
                }
            }
        }
    }
}
