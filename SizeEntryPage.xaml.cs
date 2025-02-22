using MagazinOnlineHaine.Data;
using MagazinOnlineHaine.Models;
using System.Collections.Generic;
using Size = MagazinOnlineHaine.Models.Size;

namespace MagazinOnlineHaine
{
    public partial class SizeEntryPage : ContentPage
    {
        private readonly MagazinOnlineDatabase _database;
        private Size _selectedSize;

        public SizeEntryPage()
        {
            InitializeComponent();
            _database = new MagazinOnlineDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MagazinOnlineDatabase.db"));
            LoadSizes();
        }

        private void LoadSizes()
        {
            List<Size> sizes = _database.GetSizes();
            SizesCollectionView.ItemsSource = sizes;
        }

        private void OnSizeSelected(object sender, SelectionChangedEventArgs e)
        {
            _selectedSize = e.CurrentSelection.FirstOrDefault() as Size;
            if (_selectedSize != null)
            {
                SizeNameEntry.Text = _selectedSize.SizeName;
            }
        }

        private void OnSaveSizeClicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SizeNameEntry.Text))
            {
                DisplayAlert("Eroare", "Te rog introdu un nume pentru mărime.", "OK");
                return;
            }

            if (_selectedSize == null)
            {
                var newSize = new Size { SizeName = SizeNameEntry.Text };
                _database.SaveSize(newSize);
            }
            else
            {
                _selectedSize.SizeName = SizeNameEntry.Text;
                _database.SaveSize(_selectedSize);
            }

            _selectedSize = null;
            SizeNameEntry.Text = string.Empty;
            LoadSizes();
        }

        private async void OnDeleteSizeClicked(object sender, System.EventArgs e)
        {
            if (_selectedSize != null)
            {
                bool confirm = await DisplayAlert("Confirmă", "Sigur vrei să ștergi această mărime?", "Da", "Nu");
                if (confirm)
                {
                    _database.DeleteSize(_selectedSize);
                    LoadSizes();
                }
            }
        }
    }
}