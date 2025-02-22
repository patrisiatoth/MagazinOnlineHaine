using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MagazinOnlineHaine.Models
{
    public class Size
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SizeName { get; set; }
        [ManyToMany(typeof(ProductSize), CascadeOperations = CascadeOperation.All)]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
