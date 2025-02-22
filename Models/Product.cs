using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MagazinOnlineHaine.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        public double Price { get; set; }
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Category))]
        public int? CategoryId { get; set; }

        [ManyToOne]
        public Category? Category { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}
