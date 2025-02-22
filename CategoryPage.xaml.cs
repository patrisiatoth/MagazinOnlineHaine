using MagazinOnlineHaine.Data;
using MagazinOnlineHaine.Models;
using System.Collections.Generic;

namespace MagazinOnlineHaine
{
    public partial class CategoryPage : ContentPage
    {
        private readonly MagazinOnlineDatabase _database;

        public CategoryPage()
        {
            InitializeComponent();
            _database = new MagazinOnlineDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MagazinOnlineDatabase.db"));

            LoadCategories();
        }

        private void LoadCategories()
        {
            List<Category> categories = _database.GetCategories();
            CategoriesCollectionView.ItemsSource = categories;
        }

        private async void OnCategorySelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Category selectedCategory)
            {
                await Navigation.PushAsync(new ProductPage(selectedCategory));
            }

            CategoriesCollectionView.SelectedItem = null;
        }

    }
}