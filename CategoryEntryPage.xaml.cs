using MagazinOnlineHaine.Data;
using MagazinOnlineHaine.Models;
using System.Collections.Generic;

namespace MagazinOnlineHaine
{
    public partial class CategoryEntryPage : ContentPage
    {
        private readonly MagazinOnlineDatabase _database;
        private Category? _selectedCategory;

        public CategoryEntryPage()
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

        private void OnCategorySelected(object sender, SelectionChangedEventArgs e)
        {
            _selectedCategory = e.CurrentSelection.FirstOrDefault() as Category;
            if (_selectedCategory != null)
            {
                CategoryNameEntry.Text = _selectedCategory.CategoryName;
            }
        }

        private void OnSaveCategoryClicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CategoryNameEntry.Text))
            {
                DisplayAlert("Eroare", "Te rog introdu un nume pentru categorie.", "OK");
                return;
            }

            if (_selectedCategory == null)
            {
                var newCategory = new Category { CategoryName = CategoryNameEntry.Text };
                _database.SaveCategory(newCategory);
            }
            else
            {
                _selectedCategory.CategoryName = CategoryNameEntry.Text;
                _database.SaveCategory(_selectedCategory);
            }

            _selectedCategory = null;
            CategoryNameEntry.Text = string.Empty;
            LoadCategories();
        }

        private async void OnDeleteCategoryClicked(object sender, System.EventArgs e)
        {
            if (_selectedCategory != null)
            {
                bool confirm = await DisplayAlert("Confirmă", "Sigur vrei să ștergi această categorie?", "Da", "Nu");
                if (confirm)
                {
                    _database.DeleteCategory(_selectedCategory);
                    LoadCategories();
                }
            }
        }
    }
}