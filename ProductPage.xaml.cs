using MagazinOnlineHaine.Data;
using MagazinOnlineHaine.Models;
using System.Collections.Generic;

namespace MagazinOnlineHaine
{
    public partial class ProductPage : ContentPage
    {
        private readonly MagazinOnlineDatabase _database;
        private readonly Category _selectedCategory;

        public ProductPage(Category selectedCategory)
        {
            InitializeComponent();
            _database = new MagazinOnlineDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydatabase.db"));
            _selectedCategory = selectedCategory;

            Title = _selectedCategory.CategoryName;

            LoadProducts();
        }

        private void LoadProducts()
        {
            List<Product> products = _database.GetProducts()
                .Where(p => p.CategoryId == _selectedCategory.Id)
                .ToList();
            ProductsCollectionView.ItemsSource = products;
        }
    }
}