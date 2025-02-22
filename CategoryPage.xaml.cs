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

            InitializeDatabase();
            LoadCategories();
        }

        private void InitializeDatabase()
        {

            if (!_database.GetCategories().Any())
            {
                var sampleCategories = new List<Category>
                {
                    new Category { CategoryName = "Dresses" },
                    new Category { CategoryName = "Pants" },
                    new Category { CategoryName = "Skirts" }
                };

                foreach (var category in sampleCategories)
                {
                    _database.SaveCategory(category);
                }
            }
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