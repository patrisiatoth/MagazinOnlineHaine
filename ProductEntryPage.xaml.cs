using MagazinOnlineHaine.Data;
using MagazinOnlineHaine.Models;
using System.Collections.Generic;
using System.Linq;

namespace MagazinOnlineHaine
{
    public partial class ProductEntryPage : ContentPage
    {
        private readonly MagazinOnlineDatabase _database;

        public ProductEntryPage()
        {
            InitializeComponent();
            _database = new MagazinOnlineDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MagazinOnlineDatabase.db"));
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = _database.GetCategories();
            CategoryPicker.ItemsSource = categories;
            CategoryPicker.ItemDisplayBinding = new Binding("CategoryName");
        }

        private void OnSaveButtonClicked(object sender, System.EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(PriceEntry.Text))
            {
                DisplayAlert("Eroare", "Te rog completează toate câmpurile.", "OK");
                return;
            }

            if (!double.TryParse(PriceEntry.Text, out double price))
            {
                DisplayAlert("Eroare", "Prețul introdus nu este valid.", "OK");
                return;
            }

            var product = new Product
            {
                Name = NameEntry.Text,
                Price = price,
                ImageUrl = ImageUrlEntry.Text,
                CategoryId = (CategoryPicker.SelectedItem as Category)?.Id
            };

            _database.SaveProduct(product);

            DisplayAlert("Succes", "Produsul a fost salvat cu succes.", "OK");

            NameEntry.Text = string.Empty;
            PriceEntry.Text = string.Empty;
            ImageUrlEntry.Text = string.Empty;
            CategoryPicker.SelectedItem = null;
        }
    }
}