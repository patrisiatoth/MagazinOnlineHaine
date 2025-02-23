using MagazinOnlineHaine.Data;
using MagazinOnlineHaine.Models;
using System.Collections.Generic;

namespace MagazinOnlineHaine
{
    public partial class ProductPage : ContentPage
    {
        private readonly MagazinOnlineDatabase _database;

        public ProductPage()
        {
            InitializeComponent();
            _database = new MagazinOnlineDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MagazinOnlineDatabase.db"));
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _database.GetProductsWithChildren();
            ProductsCollectionView.ItemsSource = products;
        }
    }
}