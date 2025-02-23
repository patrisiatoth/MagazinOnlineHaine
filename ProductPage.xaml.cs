using MagazinOnlineHaine.Data;
using MagazinOnlineHaine.Models;
using System.Collections.Generic;

namespace MagazinOnlineHaine
{
    public partial class ProductPage : ContentPage
    {
        private readonly MagazinOnlineDatabase _database;
        private readonly Category _selectedCategory;

        public ProductPage(object parameter)
        {
            InitializeComponent();
            _database = new MagazinOnlineDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MagazinOnlineDatabase.db"));
            _selectedCategory = parameter as Category;
            Title = _selectedCategory?.CategoryName;
            LoadProducts();
        }

        public ProductPage()
        {
            InitializeComponent();
            _database = new MagazinOnlineDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MagazinOnlineDatabase.db"));
            LoadProducts();
        }

        private void LoadProducts()
        {
            if (_selectedCategory != null)
            {
                var products = _database.GetProductsWithChildren()
                                       .Where(p => p.CategoryId == _selectedCategory.Id)
                                       .ToList();
                ProductsCollectionView.ItemsSource = products;
            }
        }
    }
}