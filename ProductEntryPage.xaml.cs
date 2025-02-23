using MagazinOnlineHaine.Data;
using MagazinOnlineHaine.Models;
using System.Collections.Generic;
using System.Linq;

namespace MagazinOnlineHaine
{
    public partial class ProductEntryPage : ContentPage
    {
        private readonly MagazinOnlineDatabase _database;
        private Product _selectedProduct;

        public ProductEntryPage()
        {
            InitializeComponent();
            _database = new MagazinOnlineDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MagazinOnlineDatabase.db"));
            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            var categories = _database.GetCategories();
            CategoryPicker.ItemsSource = categories;
            CategoryPicker.ItemDisplayBinding = new Binding("CategoryName");
        }

        private void LoadProducts()
        {
            var products = _database.GetProductsWithChildren();
            ProductsCollectionView.ItemsSource = products;
        }

        private void OnProductSelected(object sender, SelectionChangedEventArgs e)
        {
            _selectedProduct = e.CurrentSelection.FirstOrDefault() as Product;
            if (_selectedProduct != null)
            {
                NameEntry.Text = _selectedProduct.Name;
                PriceEntry.Text = _selectedProduct.Price.ToString();
                ImageUrlEntry.Text = _selectedProduct.ImageUrl;
                CategoryPicker.SelectedItem = (_database.GetCategories().FirstOrDefault(c => c.Id == _selectedProduct.CategoryId));
            }
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

            if (_selectedProduct == null)
            {
                // Adaugă un nou produs
                var product = new Product
                {
                    Name = NameEntry.Text,
                    Price = price,
                    ImageUrl = ImageUrlEntry.Text,
                    CategoryId = (CategoryPicker.SelectedItem as Category)?.Id
                };
                _database.SaveProduct(product);
            }
            else
            {
                _selectedProduct.Name = NameEntry.Text;
                _selectedProduct.Price = price;
                _selectedProduct.ImageUrl = ImageUrlEntry.Text;
                _selectedProduct.CategoryId = (CategoryPicker.SelectedItem as Category)?.Id;
                _database.SaveProduct(_selectedProduct);
            }

            DisplayAlert("Succes", "Produsul a fost salvat cu succes.", "OK");

            _selectedProduct = null;
            NameEntry.Text = string.Empty;
            PriceEntry.Text = string.Empty;
            ImageUrlEntry.Text = string.Empty;
            CategoryPicker.SelectedItem = null;
            LoadProducts();
        }

        private async void OnDeleteButtonClicked(object sender, System.EventArgs e)
        {
            if (_selectedProduct != null)
            {
                bool confirm = await DisplayAlert("Confirmă", "Sigur vrei să ștergi acest produs?", "Da", "Nu");
                if (confirm)
                {
                    _database.DeleteProduct(_selectedProduct);
                    LoadProducts();

                    _selectedProduct = null;
                    NameEntry.Text = string.Empty;
                    PriceEntry.Text = string.Empty;
                    ImageUrlEntry.Text = string.Empty;
                    CategoryPicker.SelectedItem = null;
                }
            }
            else
            {
                await DisplayAlert("Eroare", "Nu ai selectat niciun produs pentru ștergere.", "OK");
            }
        }
    }
}