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
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [OneToMany]
        public List<Product> Products { get; set; }
    }
}
