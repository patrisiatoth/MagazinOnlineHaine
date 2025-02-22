using SQLite;
using System.Collections.Generic;
using MagazinOnlineHaine.Models;
using SQLiteNetExtensions.Extensions;
using Size = MagazinOnlineHaine.Models.Size;

namespace MagazinOnlineHaine.Data
{
    public class MagazinOnlineDatabase
    {
        readonly SQLiteConnection _database;

        public MagazinOnlineDatabase(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Product>();
            _database.CreateTable<Category>();
            _database.CreateTable<Size>();
            _database.CreateTable<ProductSize>();
            _database.CreateTable<Client>();
            _database.CreateTable<Wishlist>();
        }

        public Product GetProductWithChildren(int productId)
        {
            return _database.GetWithChildren<Product>(productId, recursive: true);
        }

        public List<Product> GetProductsWithChildren()
        {
            return _database.GetAllWithChildren<Product>(recursive: true);
        }

        public List<Product> GetProducts()
        {
            return _database.Table<Product>().ToList();
        }

        public int SaveProduct(Product product)
        {
            if (product.Id != 0)
            {
                return _database.Update(product);
            }
            else
            {
                return _database.Insert(product);
            }
        }

        public int DeleteProduct(Product product)
        {
            return _database.Delete(product);
        }

        public List<Category> GetCategories()
        {
            return _database.Table<Category>().ToList();
        }

        public int SaveCategory(Category category)
        {
            if (category.Id != 0)
            {
                return _database.Update(category);
            }
            else
            {
                return _database.Insert(category);
            }
        }

        public int DeleteCategory(Category category)
        {
            return _database.Delete(category);
        }

        public List<Size> GetSizes()
        {
            return _database.Table<Size>().ToList();
        }

        public int SaveSize(Size size)
        {
            if (size.Id != 0)
            {
                return _database.Update(size);
            }
            else
            {
                return _database.Insert(size);
            }
        }

        public int DeleteSize(Size size)
        {
            return _database.Delete(size);
        }

        public List<ProductSize> GetProductSizes()
        {
            return _database.Table<ProductSize>().ToList();
        }

        public int SaveProductSize(ProductSize productSize)
        {
            return _database.Insert(productSize);
        }

        public int DeleteProductSize(ProductSize productSize)
        {
            return _database.Delete(productSize);
        }
    }
}
